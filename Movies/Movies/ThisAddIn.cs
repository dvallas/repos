using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using Movies;
using Extensibility;

namespace Movies
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }
        private IAddInUtilities utilities { get; set; }
        private IAddInUtilities AddInUtilities()
        {
            Protected object RequestComAddInAutomationService()
            {
                utilities??Return New AddInUtilities();
            }
        }

        public void ContinuedWrapper()
        {
            RunMacro(this.Application, new object[] { "ImportedMacros.Continued" });
            ImportedMacros.Continued(this.Application);
        }
        private void CreateRoadmap()
        {
            var doc = new Word.Document();
            var roadmapList=new GetRoadmap().GetOccurancesOfStyle("sSlugline", this.Application);
            foreach (var b in roadmapList)
                doc.Paragraphs[0].Range.InsertBefore(b);
            Application.Documents.Add(doc);
        }

        [ComVisible(true)]
        public interface IAddInUtilities
        {
            Object ImportData();
        }

        [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
        public class GetRoadmap : IAddInUtilities, IDTExtensibility2
        {
            public object ImportData()
            {
                return new object();
            }

            public void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
            {
                throw new NotImplementedException();
            }

            public void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
            {
                throw new NotImplementedException();
            }

            public void OnAddInsUpdate(ref Array custom)
            {
                throw new NotImplementedException();
            }

            public void OnStartupComplete(ref Array custom)
            {
                throw new NotImplementedException();
            }

            public void OnBeginShutdown(ref Array custom)
            {
                throw new NotImplementedException();
            }
         public List<string> GetOccurancesOfStyle(string style, Word.Application thisApp)
         {
             Word.Application app = thisApp;
            string styleName= style;
            List<string> list = new List<string>();
            var doc = app.ActiveDocument;
            foreach (Paragraph p in doc.Paragraphs)
            {
                if (p.get_Style() == styleName)
                    list.Add(p.ToString());
            }
            return list;
        }
       }

        public static DialogResult ShowDialog(Form dialog)
        {
            NativeWindow mainWindow = new NativeWindow();
            mainWindow.AssignHandle(Process.GetCurrentProcess().MainWindowHandle);
            DialogResult dialogResult = dialog.ShowDialog(mainWindow);
            mainWindow.ReleaseHandle();
            return dialogResult;
        }
        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }
        private void RunMacro(object oApp, object[] oRunArgs)
        {
            oApp.GetType().InvokeMember("Run",
                System.Reflection.BindingFlags.Default |
                System.Reflection.BindingFlags.InvokeMethod,
                null, oApp, oRunArgs);
        }
        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
