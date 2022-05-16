using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Amazon S3
using Amazon.S3;
using Amazon.S3.Model;


namespace StatRecoveryExercise.Models
{
    internal class S3Insert
    {
        //This class would have a method that would take the dictionary from the ParseCSV function and attempt to insert files into the S3 bucket.
        // This method would need to keep track of the file that was processed, which zip file it came from and when it was processed by inserting into the S3 Metadata.
        public async Task InsertFile(AmazonS3Client s3Client, string bucketName) // additional paramter would be an S3 Object to insert (PDF, file name etc)
        {
            await s3Client.PutObjectAsync(new Amazon.S3.Model.PutObjectRequest
            {
                BucketName = bucketName,
                Key = $"{Guid.NewGuid()}.txt",
                ContentType = "text/plain",
                ContentBody = "test sample insert"
            });
        }
    }
}
