using ImageManipulation.Model;
using ImageManipulation.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ImageManipulation.BLL
{
    public class ImageFilterBLL
    {
        private readonly string _imageSavePath = ConfigurationManager.AppSettings["imageSavePath"];

        public List<string> HandleImageFilters(List<ImageWithEffects> imageWithEffects)
        {
            List<string> listOfPaths = new List<string>();
            try
            {
                foreach(var item in imageWithEffects)
                {
                    listOfPaths.Add(ProcessImageFilters(item));
                }
            }
            catch (Exception)
            {

                throw;
            }
            return listOfPaths;
        }


        public string ProcessImageFilters(ImageWithEffects imageWithEffects)
        {
            string filteredImageUrl = string.Empty;
            try
            {
                var uploadedImage = imageWithEffects.UploadedImage;
                if (uploadedImage != null)
                {
                    string rootPath = HttpContext.Current.Server.MapPath(_imageSavePath);

                    string imageFileName = uploadedImage.FileName;
                    string docPath = "UploadedImages\\" + Share.ImageType.original.ToString() + "\\";
                    Directory.CreateDirectory(rootPath + docPath);
                    string filePath = rootPath + docPath + imageFileName;

                    //delete if file already exists
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    //save originally uploaded image to server
                    uploadedImage.SaveAs(filePath);


                    //make the necessary changes to the uploaded image based on the given filters by the user
                    //..
                    //..
                    //..

                    //assume that editedImage variable is the image that was filtered
                    HttpPostedFileBase editedImage = uploadedImage; //equated to instantiate the object


                    //save the edited image to the server and return its absolute path
                    string editedImageFileName = uploadedImage.FileName;
                    string editedImageDocPath = "UploadedImage\\" + Share.ImageType.filtered.ToString() + "\\";
                    Directory.CreateDirectory(rootPath + editedImageDocPath);
                    string editImageFilePath = rootPath + docPath + imageFileName;

                    //delete if file already exists
                    if (File.Exists(editImageFilePath))
                    {
                        File.Delete(editImageFilePath);
                    }

                    //save edited image to server
                    editedImage.SaveAs(editImageFilePath);

                    //absolute url link
                    filteredImageUrl = _imageSavePath + editedImageDocPath + editedImageFileName;
                }
            
            }
            catch (Exception)
            {

                throw;
            }

            return filteredImageUrl;
        }
    }
}
