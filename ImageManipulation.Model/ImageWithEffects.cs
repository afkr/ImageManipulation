using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ImageManipulation.Model
{
   public class ImageWithEffects
    {
        public HttpPostedFileBase UploadedImage { get; set; }
        public int Radius { get; set; }
        public int Size { get; set; }
        public int BlurPixelSize { get; set; }
        public List<ImageFilters> ListOfEffects { get; set; }
    }


    //the list of image filters can be added here
    public class ImageFilters
    {
        public bool IsGrayscale { get; set; }
        //more filters can be added as required
    }
}
