using System;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.IO.Compression;
using StatRecoveryExercise.Models;

//Amazon S3
using Amazon.S3;
using Amazon.S3.Model;

//var bucketName = BUCKETNAME
//var regionName = REGIONNAME
//var accessKey = ACCESSKEY
//var secretKey = SECRETYKEY

var s3Client = new AmazonS3Client(accessKey, secretKey, regionName);

S3Read s3Read = new S3Read();
await s3Read.ListObjects(s3Client, bucketName);

//S3Insert s3Insert = new S3Insert();
//await s3Insert.InsertFile(s3Client, bucketName);

Dictionary<string, string[]> ParseCSV(string CSV)
{
    //This function would parse a provided CSV and return a dictionary looking like "{PONumber}:{FileName1.pdf}, {FileName2.PDF}"
    Dictionary<string, string[]> parsedCSV = new Dictionary<string, string[]>();
    return parsedCSV;
}