using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    [Authorize]
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string tracking)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator code = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrcode = code.CreateQrCode(tracking, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap visual = qrcode.GetGraphic(10))
                {
                    visual.Save(ms, ImageFormat.Png);
                    ViewBag.codeimage="data:image/png;base64,"+Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}