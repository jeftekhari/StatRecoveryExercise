using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Threading.Tasks;

//Amazon S3
using Amazon.S3;
using Amazon.S3.Model;

namespace StatRecoveryExercise.Models
{
    internal class S3Read
    {
        public async Task ListObjects(AmazonS3Client s3Client, string bucketName)
        {
            var objects = await s3Client.ListObjectsAsync(bucketName);
            Console.WriteLine($"S3 Objects found: {objects.S3Objects.Count}");

            if (objects != null)
            {
                foreach (var s3Object in objects.S3Objects)
                {
                    var objectResponse = await s3Client.GetObjectAsync(new GetObjectRequest
                    {
                        BucketName = bucketName,
                        Key = s3Object.Key
                    });

                    Console.WriteLine($"Object name: {s3Object.Key} \n");

                    //Copy to Memory Stream to Unzip
                    Stream streamData = new MemoryStream();
                    objectResponse.ResponseStream.CopyTo(streamData);

                    ZipArchive archive = new ZipArchive(streamData);
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        Console.WriteLine(entry.FullName);
                        if (entry.FullName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                        {
                            using StreamReader sr = new StreamReader(entry.Open());
                            Console.WriteLine(sr.ReadToEnd());
                        }
                    }
                }
            }
            // The metadata for the files can be accessed here in the read model or in the insert process as a final check prior to inserting to the S3 bucket.
            // This function is missing a way to store the files in persistent memory between functions
        }
    }
}
