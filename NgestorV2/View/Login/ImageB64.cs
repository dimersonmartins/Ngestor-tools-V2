using System;
using System.Drawing;
using System.IO;

namespace NgestorFieldServiceTools.View.Login
{
    class ImageB64
    {
        public Image imgngestor_url_server()
        {
            byte[] base64 = Convert.FromBase64String("iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAMAAAAoLQ9TAAAAA3NCSVQICAjb4U/gAAAACXBIWXMAAAPRAAAD0QGYiom0AAAAGXRFWHRTb2Z0d2FyZQB3d3cuaW5rc2NhcGUub3Jnm+48GgAAAGZQTFRFRU9pSVJtVGCARU5lS1VwVWCAVWCAQkpgQkpgRExjR1BqSFBqSFFsSVJtSVJuSlNvUl1/VWCAVmGCV2KEV2SGWGOGWGSGWGSHWWSIWWWIWWWJWmWKW2eMW2eNY3CdZ3WnbHuyc4O/Ut0PYQAAAAh0Uk5TenqUxMTg7PhJbSXtAAAAa0lEQVQYV2WPSQ7CMBAEqyfEYcnF4v9/jIQiIovxcAKM3ceSepNNtHJlUmmJ8nryB6BkIp4o2+o7wAV3i5fSrTWwiz500R8Inef7dgCaTEThC1jwCOpoUR861H6GaTYRx286V2qFMp7r778B41YnpuQ6QLsAAAAASUVORK5CYII=");
            Image image;
            using (MemoryStream ms = new MemoryStream(base64))
            {
                image = Image.FromStream(ms);
            }

            return image;
        }
    }
}
