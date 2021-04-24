IronPDF  - The PDF Library for .Net 
=============================================================
https://ironpdf.com/

Installation for .Net Framework 4.0 + 
=============================================================
- Include all dlls in net40 or net45 folder into your project
- Add Assembly references to:
	* System.Drawing
	* System.Web
	* System.Configuration


Installation for .Net Standard & .Net Core 2.0+  & .Net 5
=============================================================
- Include all dlls in netstandard2.0 folder into your project
- Add a Nuget package references to:
	* System.Drawing.Common 4.7+  (https://www.nuget.org/packages/System.Drawing.Common/4.7.0)
	

Compatibility
=============================================================
Supports applications and websites developed in 
- .Net FrameWork 4 (and above) for Windows and Azure
- .Net Core 2, 3 (and above) for Windows, Linux, MacOs and Azure
- .Net 5

C# Code Example
=============================================================
```
using IronPdf;

var Renderer = new IronPdf.HtmlToPdf();
Renderer.RenderHtmlAsPdf("<h1>Html with CSS and Images</h1>").SaveAs("example.pdf");
```

Documentation
=============================================================

- Code Samples				:	https://ironpdf.com/examples/using-html-to-create-a-pdf/
- MSDN Class Reference		:	https://ironpdf.com/c%23-pdf-documentation/
- Tutorials					:	https://ironpdf.com/tutorials/html-to-pdf/
- Support					:	developers@ironsoftware.com
