using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies
{
    static class ImportedMacros
    {
        public static void Continued(Application app)
        {
            //
            // Continued Macro
            // Adds (CONTINUED) and CONTINUED:
            //
            //app.ActiveDocument.Range.Selection
            //        {
            //        .TypeParagraph,
            //    .Style = ActiveDocument.Styles("sAction"),
            //    Selection.TypeParagraph,
            //    Selection.MoveUp Unit:= wdLine, Count:= 1,
            //    Selection.Style = ActiveDocument.Styles("sDISSOLVE:"),
            //    Selection.TypeText Text:= "(CONTINUED)",
            //    Selection.InsertBreak Type:= wdPageBreak,
            //    Selection.Style = ActiveDocument.Styles("sSlugline"),
            //    Selection.TypeText Text:= vbTab & "continued: ()" & vbTab & vbTab,
            //    Selection.TypeParagraph,
            //    Selection.MoveLeft Unit:= wdCharacter, Count:= 4;
            //}
        }
        public static void More()
        {
            //// More Macro
            //// Breaks the page and adds (MORE) and (CONT//D)
            ////
            //    Selection.TypeParagraph
            //    Selection.TypeParagraph
            //    Selection.Delete Unit:=wdCharacter, Count:=1
            //    Selection.MoveUp Unit:=wdLine, Count:=1
            //    Selection.Style = ActiveDocument.Styles("More")
            //    Selection.TypeText Text:="(MORE)"
            //    Selection.InsertBreak Type:=wdPageBreak
            //    Selection.Style = ActiveDocument.Styles("Character")
            //    Selection.TypeText Text:=" (CONT//D)"
            //    Selection.TypeParagraph
            //    Selection.MoveUp Unit:=wdLine, Count:=1
            //    Selection.HomeKey Unit:=wdLine
        }
        public static void Name()
        {
            //// Character Macro
            //// Macro created 12/18/97 by Dean Vallas
            ////
            //WordBasic.Style "sCharacter Name"
            //if (this.KeyPress() = wdKeyReturn)
            //        {
            //            MsgBox "name pressed";
            //            WordBasic.InsertPara;
            //    WordBasic.Style "sDialog";
            //}

        }
        public static void Dialog()
        {
            //// Dialog Macro
            //// Macro created 05/09/97 by Dean Vallas
            ////
            //WordBasic.Style "sDialog"
            //If this.KeyPress() = wdKeyReturn Then
            //    WordBasic.InsertPara
            //    WordBasic.Style "sSlugline"
            //End If

        }

        public static void CreateRoadmapWindow()
        {
            //    // CreateRoadmapWindow Macro
            //    // Macro recorded 05/09/97 by Dean Vallas
            //    //
            //    var strRoadmap;
            //Selection.HomeKey Unit:=wdStory
            ////
            //// Dialog Macro
            //// Macro created 05/09/97 by Dean Vallas
            ////

            //    //Do While True
            //    Selection.Find.ClearFormatting;
            //    Selection.Find.Style = ActiveDocument.Styles("sSlugline")
            //    With Selection.Find
            //        .Text = ""
            //        .Replacement.Text = ""
            //        .Forward = True
            //        .Wrap = wdFindAsk
            //        .Format = True
            //        .MatchCase = False
            //        .MatchWholeWord = False
            //        .MatchWildcards = False
            //        .MatchSoundsLike = False
            //        .MatchAllWordForms = False
            //    Selection.Find.Execute
            //    Selection.Copy
            //    strRoadmap = strRoadmap & vbCrLf & Selection
            //    End With
            //   //     Exit Do

            //    //Loop
            //    MsgBox (strRoadmap)
        }
        public static void InsertParenthetical()
        {
            //// InsertParenthetical Macro
            //// Macro recorded 12/19/97 by Dean Vallas
            ////
            //    Selection.Style = ActiveDocument.Styles("sDirection")
            //    Selection.TypeText Text:="()"
            //    Selection.MoveLeft Unit:=wdCharacter, Count:=1
        }
        public static void UPPER()
        {
            //// UPPER Macro
            //// Change Case to UPPER
            ////
            //    Selection.Range.Case = wdUpperCase
        }
        public static void lower()
        {
            //// lower Macro
            //// Change Case to lower
            ////
            //    Selection.Range.Case = wdLowerCase
        }
        public static void Macro1()
        {
            //// Macro1 Macro
            //// Add All Names to AutoText List
            ////
            //    Selection.Style = ActiveDocument.Styles("sCharacter Name")
            //    //Selection.TypeText Text:="joe"
            //    Selection.HomeKey Unit:=wdLine, Extend:=wdExtend
            //    Selection.Copy
            //    Application.DisplayAutoCompleteTips = False
        }
        public static void AddNameToAutoText()
        {
            //// AddNameToAutoText Macro
            //// Macro written 12/20/98 by Dean Vallas
            ////
            //    Selection.Style = ActiveDocument.Styles("sCharacter Name")


            //    Selection.HomeKey Unit:=wdLine, Extend:=wdExtend
            //    //Selection.EndKey Unit:=wdLine, Extend:=wdExtend
            //    ActiveDocument.AttachedTemplate.AutoTextEntries.Add _
            //    Name:=Selection, Range:=Selection.Range

            //    Selection.MoveRight Unit:=wdCharacter, Count:=1
            //    Selection.TypeText Text:=Paragraph
            //    Selection.TypeText Text:=Paragraph

        }

        public static void CollectNamesToMsgBox()
        {
            //// CollectNamesToMsgBox Macro
            //// Collect Character Names and Display
            ////
            //var strMsg As String

            //For Each i In ActiveDocument.AttachedTemplate.AutoTextEntries
            //   strMsg = strMsg & UCase(i.Name) & Chr(13) & Chr(10)
            //Next i

            //MsgBox strMsg

        }
    }
}
