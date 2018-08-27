using System;
using System.Web;
using System.IO;

namespace RESAERCHMENTOR.NET.Controllers
{
    public class UploadManager
    {
        public bool UploadFile(System.Web.UI.WebControls.FileUpload f, string message)
        {
            if (!f.HasFile)
            {
                message = "No file is selected.";
                return false;
            }

            string sessionid;

            // Get the current HTTPContext
            HttpContext context = HttpContext.Current;
            sessionid = context.Session.SessionID;

            string fileExtension = System.IO.Path.GetExtension(f.FileName).ToLower();
            string[] allowedExtensions = new[] { ".jpeg", ".jpg", ".bmp", ".png" };
            int counter;

            for (counter = 0; counter <= allowedExtensions.Length; counter += 1)
            {
                try
                {
                    if (fileExtension == allowedExtensions[counter])
                    {
                        System.Drawing.Bitmap myImage = new System.Drawing.Bitmap(120, 140);

                        try
                        {
                            string path = context.Server.MapPath("~/UploadedImages/");
                            string filename = sessionid + DateTime.Now.Millisecond.ToString() + ".jpg";
                            string fullpath = path + filename;
                            f.PostedFile.SaveAs(fullpath);

                            myImage = new System.Drawing.Bitmap(fullpath);
                            // Dim ImgSize As Integer = myImage.( )


                            if ((myImage.Width >= 110 & myImage.Width <= 130) & (myImage.Height >= 130 & myImage.Height <= 150))
                            {
                                // message = "/UploadedImages" + filename
                                message = "~/UploadedImages/" + filename;
                                return true;
                            }
                            else
                            {
                                message = "Invalid Picture size! The Passport Photograph must be of size 120 X 140px";
                                return false;
                            }
                        }
                        catch (Exception ex)
                        {
                            // NavyWebDAL.AppException.LogError(ex.Message, ex.StackTrace.ToString)
                            message = "Image could not be uploaded at the moment.";
                            return false;
                        }
                        finally
                        {
                            myImage.Dispose();
                        }
                    }
                }


                catch (Exception ex)
                {
                    message = "Invalid File Type.";
                    return false;
                }
            }

            message = "Invalid Picture format! The Passport Photograph must a jpeg.";
            return false;
        }
        public bool UploadPhotogragh(ref System.Web.UI.WebControls.FileUpload f, ref string message)
        {
            if (!f.HasFile)
            {
                message = "No file is selected.";
                return false;
            }

            string sessionid;

            // Get the current HTTPContext
            HttpContext context = HttpContext.Current;
            sessionid = context.Session.SessionID;

            string fileExtension = System.IO.Path.GetExtension(f.FileName).ToLower();
            string[] allowedExtensions = new[] { ".jpeg", ".jpg", ".bmp", ".png" };
            int counter;

            for (counter = 0; counter <= allowedExtensions.Length; counter += 1)
            {
                try
                {
                    if (fileExtension == allowedExtensions[counter])
                    {
                        System.Drawing.Bitmap myImage = new System.Drawing.Bitmap(480, 672);

                        try
                        {
                            string path = context.Server.MapPath("~/UploadedImages/");
                            string filename = sessionid + DateTime.Now.Millisecond.ToString() + ".jpg";
                            string fullpath = path + filename;
                            f.PostedFile.SaveAs(fullpath);

                            myImage = new System.Drawing.Bitmap(fullpath);
                            // Dim ImgSize As Integer = myImage.( )


                            // If (myImage.Width >= 460 And myImage.Width <= 675) And (myImage.Height >= 500 And myImage.Height <= 680) Then
                            // message = "/UploadedImages" + filename
                            message = "~/UploadedImages/" + filename;
                            return true;
                        }
                        // Else
                        // message = "Invalid Picture size! The Passport Photograph must be of size 120 X 140px"
                        // Return False
                        // End If

                        catch (Exception ex)
                        {
                            // NavyWebDAL.AppException.LogError(ex.Message, ex.StackTrace.ToString)
                            message = "Image could not be uploaded at the moment.";
                            return false;
                        }
                        finally
                        {
                            myImage.Dispose();
                        }
                    }
                }


                catch (Exception ex)
                {
                    message = "Invalid File Type.";
                    return false;
                }
            }

            message = "Invalid Picture format! The Passport Photograph must a jpeg.";
            return false;
        }
        public static string ReturnPicturePath(string picturename, byte[] picByte, bool rootFolder)
        {

            // Dim _appPhotoImage As String = "eImmigration\TemImages\"
            HttpContext _context = HttpContext.Current;

            // Path to write Image to
            string relPath = picturename;
            string mpath = _context.Server.MapPath("~/" + relPath);
            BinaryWriter binWriter = null;
            bool _Status = false;


            try
            {
                binWriter = new BinaryWriter(File.Open(mpath, FileMode.Create));
                binWriter.Write(picByte);
                _Status = true;
            }
            catch (Exception ex)
            {
                // NavyWebDAL.AppException.LogError(ex.Message, ex.StackTrace.ToString)
                _Status = false;
            }
            finally
            {
                binWriter.Close();
                binWriter = null;
            }

            if (_Status)
            {
                if (rootFolder == false)
                    relPath = "~/" + relPath;
                return relPath;
            }
            else
                return null;
        }
        public byte[] GetDefaultImage()
        {
            byte[] sy;
            System.Text.ASCIIEncoding dy = new System.Text.ASCIIEncoding();
            sy = dy.GetBytes("seyi");
            return sy;
        }
        public bool UploadDocumentFile(ref System.Web.UI.WebControls.FileUpload f, ref string message)
        {
            if (!f.HasFile)
            {
                message = "No file is selected.";
                return false;
            }

            string sessionid;

            // Get the current HTTPContext
            HttpContext context = HttpContext.Current;
            sessionid = context.Session.SessionID;

            string fileExtension = System.IO.Path.GetExtension(f.FileName).ToLower();
            string[] allowedExtensions = new[] { ".jpeg", ".jpg" };
            int counter;

            for (counter = 0; counter <= allowedExtensions.Length; counter += 1)
            {
                if (fileExtension == allowedExtensions[counter])
                {
                    System.Drawing.Bitmap myImage = new System.Drawing.Bitmap(120, 140);

                    try
                    {
                        string path = context.Server.MapPath("~/UploadedImages/");
                        string filename = sessionid + DateTime.Now.Millisecond.ToString() + ".jpg";
                        string fullpath = path + filename;
                        f.PostedFile.SaveAs(fullpath);

                        myImage = new System.Drawing.Bitmap(fullpath);

                        // If (myImage.Width >= 300 And myImage.Width <= 400) And (myImage.Height >= 400 And myImage.Height <= 700) Then
                        // message = "/UploadedImages" + filename
                        message = "~/UploadedImages/" + filename;
                        return true;
                    }
                    // Else
                    // message = "Invalid Picture size! The Passport Photograph must be of size 400 X 700px"
                    // Return False
                    // End If

                    catch (Exception ex)
                    {
                        // NavyWebDAL.AppException.LogError(ex.Message, ex.StackTrace.ToString)
                        message = "Image could not be uploaded at the moment.";
                        return false;
                    }
                    finally
                    {
                        myImage.Dispose();
                    }
                }
            }
            message = "Invalid Picture format! The Passport Photograph must a jpeg.";
            return false;
        }
        public static string ReturnDocumentPath(string picturename, byte[] picByte, bool rootFolder)
        {

            // Dim _appPhotoImage As String = "eImmigration\TemImages\"
            HttpContext _context = HttpContext.Current;

            // Path to write Image to
            string relPath = picturename;
            string mpath = _context.Server.MapPath("~/" + relPath);
            BinaryWriter binWriter = null;
            bool _Status = false;


            try
            {
                binWriter = new BinaryWriter(File.Open(mpath, FileMode.Create));
                binWriter.Write(picByte);
                _Status = true;
            }
            catch (Exception ex)
            {
                // NavyWebDAL.AppException.LogError(ex.Message, ex.StackTrace.ToString)
                _Status = false;
            }
            finally
            {
                binWriter.Close();
                binWriter = null;
            }

            if (_Status)
            {
                if (rootFolder == false)
                    relPath = "~/" + relPath;
                return relPath;
            }
            else
                return null;
        }
    }
}