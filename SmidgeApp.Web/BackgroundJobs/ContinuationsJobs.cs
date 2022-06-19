using System.Diagnostics;

namespace SmidgeApp.Web.BackgroundJobs
{
    public class ContinuationsJobs
    {

        public static void WriteWatermarkStatusJob(string id, string fileName)
        {
            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{id} - {fileName} başarılı bir şekilde watermark ekllendi"));
        }
    }
}
