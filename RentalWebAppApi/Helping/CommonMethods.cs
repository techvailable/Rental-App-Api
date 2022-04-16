namespace WeightChopperApi.Helping
{
    public class CommonMethods
    {
        public static DayOfWeek reg_day_week;
        public static DateTime currentWeekStartDate;
        public static DateTime lastWeekStartDate;
        public CommonMethods()
        {

        }


        public static string SaveImage(IFormFile fileName, IWebHostEnvironment hostEnvironment, string type = null)
        {
            string imageName = null;
            var imagepath = string.Empty;
            if (fileName != null)
            {

                imageName = new string(Path.GetFileNameWithoutExtension(fileName.FileName).Take(10).ToArray()).Replace(' ', '_');
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileName.FileName);

                imagepath = Path.Combine(hostEnvironment.ContentRootPath, "Images", imageName);
            }
            using (var fileStream = new FileStream(imagepath, FileMode.Create))
            {
                fileName.CopyTo(fileStream);
            }

            return imageName;
        }


    }
}
