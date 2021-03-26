using System;
using System.Collections.Generic;
using System.Text;

namespace CLEAN_Domain.AppSettings
{
    public class ApplicationSettings
    {
        public ApplicationSettings()
        {
            Databases = new DatabasesSettings();
        }
        public DatabasesSettings Databases { get; set; }
    }
}
