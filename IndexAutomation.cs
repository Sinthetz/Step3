//#define __LIGHT_VERSION__
#if (__LIGHT_VERSION__)
	using Kompas6LTAPI5;
#else
	using Kompas6API5;
#endif

using System;
using Microsoft.Win32;
using System.Reflection;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using KAPITypes;
using Kompas6Constants;
using static Steps.NET.Automation;
	using Application = System.Windows.Forms.Application;
	using reference = System.Int32;
using static Steps.NET.Facade;



namespace Steps.NET
{

    [ClassInterface(ClassInterfaceType.AutoDual)]
    public partial class Step3
    {
        public static KompasObject kompas;
        public static ksDocument2D doc;
        public static ksMathematic2D mat;
        public static float Visota { get; set; }
        public static float Shirina { get; set; }
        public static float IndentX { get; set; }
        public static float IndentY { get; set; }
        private static void GetPoint(ksDynamicArray arr, ksMathPointParam par)//создание математических точек (POINT_ARR)
        {
            for (int i = 0; i < arr.ksGetArrayCount(); i++)
            {
                arr.ksGetArrayItem(i, par);
            }
        }
        public static void DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
            out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
            out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
            out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
            out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
            out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
            out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
            out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
            out ksMathPointParam Point1, out ksMathPointParam Point2)//объявление базовых параметров для отрисовки объектов
        {
            docPar = (ksDocumentParam) kompas.GetParamStruct((short) StructType2DEnum.ko_DocumentParam);
            docPar1 = (ksDocumentParam) kompas.GetParamStruct((short) StructType2DEnum.ko_DocumentParam);
            par1 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model1 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model2 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model3 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model4 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model5 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model6 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model7 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model8 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model9 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model10 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model11 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model12 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model13 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model14 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model15 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model16 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model17 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model18 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model19 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model20 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            model21 = (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
            Point1 = (ksMathPointParam) kompas.GetParamStruct((short) StructType2DEnum.ko_MathPointParam);
            Point2 = (ksMathPointParam) kompas.GetParamStruct((short) StructType2DEnum.ko_MathPointParam);
        }

        public static void Zagotovka(ksRectangleParam par1) //создание заготовки
        {
            par1.x = 0; //начальные точки ...заготовка в 0( изменять только из за отступов +32/+16 и тд)
            par1.y = 0;
            par1.height = Visota; 
            par1.width = Shirina; //Важно!!! рисунок масштабируется от размера заговки которую задает пользователь
            par1.style = 6;
            doc.ksRectangle(par1);
        }

        #region =======================Econom=======================

        public static void WorkDocument()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    //создание заготовки
                    model1.x = 265; //отступы рисунка на заготовке
                    model1.y = 140;
                    model1.height = par1.height - 280;
                    model1.width = par1.width - 405;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                }
            }
        } //Эконом 1

        public static void Econom2()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                //создание фрагмента
                {
                    Zagotovka(par1);
                    //создание заготовки
                    model1.x = 265;
                    model1.y = 140;
                    model1.height = (par1.height - 280); // размер элемента
                    model1.width = (par1.width / 5);
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    //маленький квадрат
                    model2.x = (model1.width + 130 + 265);
                    model2.y = 140;
                    model2.height = (par1.height - 280);
                    model2.width = (par1.width - model2.x - 140);
                    model2.style = 1;
                    doc.ksRectangle(model2);
                    //большой квадрат
                }
            }
        }

        public static void Econom3()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                //создание фрагмента
                {
                    Zagotovka(par1); //создание заготовки
                    model1.x = 265; //отступы рисунка на заготовке
                    model1.y = 140;
                    model1.height = (par1.height / 2 - 205);
                    model1.width = (par1.width - 405) / 5.4067;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    model2.x = 265;
                    model2.y = (par1.height / 2 + 65);
                    model2.height = (par1.height / 2 - 205);
                    model2.width = (par1.width - 405) / 5.4067;
                    model2.style = 1;
                    doc.ksRectangle(model2);
                    model3.x = model2.width + 130 + 265;
                    model3.y = 140;
                    model3.height = (par1.height / 2 - 205);
                    model3.width = (par1.width - ((model2.width * 2) + 665));
                    model3.style = 1;
                    doc.ksRectangle(model3);
                    model4.x = model2.width + 130 + 265;
                    model4.y = (par1.height / 2 + 65);
                    model4.height = (par1.height / 2 - 205);
                    model4.width = (par1.width - ((model2.width * 2) + 665));
                    model4.style = 1;
                    doc.ksRectangle(model4);
                    model5.x = par1.width - 140 - model2.width;
                    model5.y = 140;
                    model5.height = (par1.height / 2 - 205);
                    model5.width = (par1.width - 405) / 5.4067;
                    model5.style = 1;
                    doc.ksRectangle(model5);
                    model6.x = par1.width - 140 - model2.width;
                    model6.y = (par1.height / 2 + 65);
                    model6.height = (par1.height / 2 - 205);
                    model6.width = (par1.width - 405) / 5.4067;
                    model6.style = 1;
                    doc.ksRectangle(model6);
                }
            }
        }

        public static void Econom4()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                //создание фрагмента
                {
                    Zagotovka(par1); //создание заготовки
                    model1.x = 265; 
                    model1.y = 140;
                    model1.height = (par1.height / 2 - 205);
                    model1.width = (par1.width - 405) / 8;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    model2.x = 265;
                    model2.y = (par1.height / 2 + 65);
                    model2.height = (par1.height / 2 - 205);
                    model2.width = (par1.width - 405) / 8;
                    model2.style = 1;
                    doc.ksRectangle(model2);
                    model3.x = model2.width + 130 + 265;
                    model3.y = 140;
                    model3.height = (par1.height / 2 - 205);
                    model3.width = (par1.width - ((model2.width * 2) + 665));
                    model3.style = 1;
                    doc.ksRectangle(model3);
                    model4.x = model2.width + 130 + 265;
                    model4.y = (par1.height / 2 + 65);
                    model4.height = (par1.height / 2 - 205);
                    model4.width = (par1.width - ((model2.width * 2) + 665));
                    model4.style = 1;
                    doc.ksRectangle(model4);
                    model5.x = par1.width - 140 - model2.width;
                    model5.y = 140;
                    model5.height = (par1.height / 2 - 205);
                    model5.width = (par1.width - 405) / 8;
                    model5.style = 1;
                    doc.ksRectangle(model5);
                    model6.x = par1.width - 140 - model2.width;
                    model6.y = (par1.height / 2 + 65);
                    model6.height = (par1.height / 2 - 205);
                    model6.width = (par1.width - 405) / 8;
                    model6.style = 1;
                    doc.ksRectangle(model6);
                }
            }
        }

        public static void Econom5()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                //создание фрагмента
                {
                    Zagotovka(par1); //создание заготовки
                    model1.x = 265; //отступы рисунка относительно заготовки
                    model1.y = 140;
                    model1.height = (par1.height / 2 - 205);
                    model1.width = (par1.width - 405);
                    model1.style = 1;
                    doc.ksRectangle(model1);// команда на отрисовку объекта в КОМПАС-3D
                    model2.x = 265; 
                    model2.y = (par1.height / 2 + 65);
                    model2.height = (par1.height / 2 - 205);
                    model2.width = (par1.width - 405);
                    model2.style = 1;
                    doc.ksRectangle(model2);
                }
            }
        }

        public static void Econom6()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                ksRectParam par = (ksRectParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectParam);
                ksDynamicArray arr = (ksDynamicArray) kompas.GetDynamicArray(ldefin2d.RECT_ARR); 
                ksMathPointParam pBot =
                    (ksMathPointParam) kompas.GetParamStruct((short) StructType2DEnum.ko_MathPointParam);
                ksMathPointParam pTop =
                    (ksMathPointParam) kompas.GetParamStruct((short) StructType2DEnum.ko_MathPointParam);
                if (arr != null && par != null && pBot != null && pTop != null)
                {
                    Zagotovka(par1);
                    model1.x = 265; 
                    model1.y = 140;
                    model1.height = (par1.height / 2 - 180);
                    model1.width = ((par1.width - 405) - 160) / 3;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    model2.x = 265 + 80 + model1.width;
                    model2.y = (par1.height / 2 + 40);
                    model2.height = (par1.height / 2 - 180);
                    model2.width = ((par1.width - 405) - 160) / 3;
                    model2.style = 1;
                    doc.ksRectangle(model2);
                    model3.x = 265 + 80 + model1.width; 
                    model3.y = 140;
                    model3.height = (par1.height / 2 - 180);
                    model3.width = ((par1.width - 405) - 160) / 3;
                    model3.style = 1;
                    doc.ksRectangle(model3);
                    model4.x = 265; 
                    model4.y = (par1.height / 2 + 40);
                    model4.height = (par1.height / 2 - 180);
                    model4.width = ((par1.width - 405) - 160) / 3;
                    model4.style = 1;
                    doc.ksRectangle(model4);
                    model5.x = 265 + 80 * 2 + (model1.width * 2);
                    model5.y = 140;
                    model5.height = (par1.height / 2 - 180);
                    model5.width = ((par1.width - 405) - 160) / 3;
                    model5.style = 1;
                    doc.ksRectangle(model5);
                    model6.x = 265 + 80 * 2 + (model1.width * 2);
                    model6.y = (par1.height / 2 + 40);
                    model6.height = (par1.height / 2 - 180);
                    model6.width = ((par1.width - 405) - 160) / 3;
                    model6.style = 1;
                    doc.ksRectangle(model6);
                }
            }
        }

        public static void Econom7()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                Zagotovka(par1); //создание заготовки
                model1.x = 265; //отступы рисунка на заготовке
                model1.y = 140;
                model1.height = (par1.height / 2 - 180);
                model1.width = ((par1.width - 405) - 240) / 4;
                model1.style = 1;
                doc.ksRectangle(model1);
                model2.x = 265 + 80 + model1.width;
                model2.y = (par1.height / 2 + 40);
                model2.height = (par1.height / 2 - 180);
                model2.width = ((par1.width - 405) - 240) / 4;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 + model1.width;
                model3.y = 140;
                model3.height = (par1.height / 2 - 180);
                model3.width = ((par1.width - 405) - 240) / 4;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265;
                model4.y = (par1.height / 2 + 40);
                model4.height = (par1.height / 2 - 180);
                model4.width = ((par1.width - 405) - 240) / 4;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80 * 2 + (model1.width * 2);
                model5.y = 140;
                model5.height = (par1.height / 2 - 180);
                model5.width = ((par1.width - 405) - 240) / 4;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265 + 80 * 2 + (model1.width * 2);
                model6.y = (par1.height / 2 + 40);
                model6.height = (par1.height / 2 - 180);
                model6.width = ((par1.width - 405) - 240) / 4;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265 + 80 * 3 + (model1.width * 3);
                model7.y = 140;
                model7.height = (par1.height / 2 - 180);
                model7.width = ((par1.width - 405) - 240) / 4;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265 + 80 * 3 + (model1.width * 3);
                model8.y = (par1.height / 2 + 40);
                model8.height = (par1.height / 2 - 180);
                model8.width = ((par1.width - 405) - 240) / 4;
                model8.style = 1;
                doc.ksRectangle(model8);
            }
        }

        public static void Econom8()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);//создание фрагмента
                Zagotovka(par1); //создание заготовки
                model1.x = 265;
                model1.y = 140;
                model1.height =((par1.height - 280) - 160) /3; //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model1.width = ((par1.width - 405) - 480) / 7; // 
                model1.style = 1;
                doc.ksRectangle(model1); //отрисовка элемента 1
                model2.x = 265 + 80 + model1.width;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = ((par1.width - 405) - 480) / 7;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 * 2 + model1.width * 2;
                model3.y = 140;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 480) / 7;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265 + 80 * 3 + model1.width * 3;
                model4.y = 140;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) - 480) / 7;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80 * 4 + model1.width * 4;
                model5.y = 140;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 480) / 7;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265 + 80 * 5 + model1.width * 5;
                model6.y = 140;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = ((par1.width - 405) - 480) / 7;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265 + 80 * 6 + model1.width * 6;
                model7.y = 140;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = ((par1.width - 405) - 480) / 7;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265;
                model8.y = 140 + 80 + model1.height;
                model8.height = ((par1.height - 280) - 160) / 3;
                model8.width = ((par1.width - 405) - 480) / 7;
                model8.style = 1;
                doc.ksRectangle(model8);
                model9.x = 265 + 80 + (model1.width);
                model9.y = 140 + 80 + model1.height;
                model9.height = ((par1.height - 280) - 160) / 3;
                model9.width = ((par1.width - 405) - 480) / 7;
                model9.style = 1;
                doc.ksRectangle(model9);
                model10.x = 265 + 80 * 2 + (model1.width * 2);
                model10.y = 140 + 80 + model1.height;
                model10.height = ((par1.height - 280) - 160) / 3;
                model10.width = ((par1.width - 405) - 480) / 7;
                model10.style = 1;
                doc.ksRectangle(model10);
                model11.x = 265 + 80 * 3 + (model1.width * 3);
                model11.y = 140 + 80 + model1.height;
                model11.height = ((par1.height - 280) - 160) / 3;
                model11.width = ((par1.width - 405) - 480) / 7;
                model11.style = 1;
                doc.ksRectangle(model11);
                model12.x = 265 + 80 * 4 + (model1.width * 4);
                model12.y = 140 + 80 + model1.height;
                model12.height = ((par1.height - 280) - 160) / 3;
                model12.width = ((par1.width - 405) - 480) / 7;
                model12.style = 1;
                doc.ksRectangle(model12);
                model13.x = 265 + 80 * 5 + (model1.width * 5);
                model13.y = 140 + 80 + model1.height;
                model13.height = ((par1.height - 280) - 160) / 3;
                model13.width = ((par1.width - 405) - 480) / 7;
                model13.style = 1;
                doc.ksRectangle(model13);
                model14.x = 265 + 80 * 6 + (model1.width * 6);
                model14.y = 140 + 80 + model1.height;
                model14.height = ((par1.height - 280) - 160) / 3;
                model14.width = ((par1.width - 405) - 480) / 7;
                model14.style = 1;
                doc.ksRectangle(model14);
                model15.x = 265;
                model15.y = 140 + 80 * 2 + model1.height * 2;
                model15.height = ((par1.height - 280) - 160) / 3;
                model15.width = ((par1.width - 405) - 480) / 7;
                model15.style = 1;
                doc.ksRectangle(model15);
                model16.x = 265 + 80 + (model1.width);
                model16.y = 140 + 80 * 2 + model1.height * 2;
                model16.height = ((par1.height - 280) - 160) / 3;
                model16.width = ((par1.width - 405) - 480) / 7;
                model16.style = 1;
                doc.ksRectangle(model16);
                model17.x = 265 + 80 * 2 + (model1.width * 2);
                model17.y = 140 + 80 * 2 + model1.height * 2;
                model17.height = ((par1.height - 280) - 160) / 3;
                model17.width = ((par1.width - 405) - 480) / 7;
                model17.style = 1;
                doc.ksRectangle(model17);
                model18.x = 265 + 80 * 3 + (model1.width * 3);
                model18.y = 140 + 80 * 2 + model1.height * 2;
                model18.height = ((par1.height - 280) - 160) / 3;
                model18.width = ((par1.width - 405) - 480) / 7;
                model18.style = 1;
                doc.ksRectangle(model18);
                model19.x = 265 + 80 * 4 + (model1.width * 4);
                model19.y = 140 + 80 * 2 + model1.height * 2;
                model19.height = ((par1.height - 280) - 160) / 3;
                model19.width = ((par1.width - 405) - 480) / 7;
                model19.style = 1;
                doc.ksRectangle(model19);
                model20.x = 265 + 80 * 5 + (model1.width * 5);
                model20.y = 140 + 80 * 2 + model1.height * 2;
                model20.height = ((par1.height - 280) - 160) / 3;
                model20.width = ((par1.width - 405) - 480) / 7;
                model20.style = 1;
                doc.ksRectangle(model20);
                model21.x = 265 + 80 * 6 + (model1.width * 6);
                model21.y = 140 + 80 * 2 + model1.height * 2;
                model21.height = ((par1.height - 280) - 160) / 3;
                model21.width = ((par1.width - 405) - 480) / 7;
                model21.style = 1;
                doc.ksRectangle(model21);
            }
        } //элементы отрисовываются столбцами

        public static void Econom9()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);//создание фрагмента
                Zagotovka(par1); //создание заготовки
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height =((par1.height - 280) - 160) /3; //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model1.width = ((par1.width - 405) - 480) / 7; // 
                model1.style = 1;
                doc.ksRectangle(model1); //отрисовка элемента 1
                model2.x = 265 + 80 + model1.width;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = ((par1.width - 405) - 320) - model1.width * 4;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 * 4 + model1.width * 4;
                model3.y = 140;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 480) / 7;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265 + 80 * 5 + model1.width * 5;
                model4.y = 140;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) - 480) / 7;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80 * 6 + model1.width * 6;
                model5.y = 140;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 480) / 7;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265;
                model6.y = 140 + 80 + model1.height;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = ((par1.width - 405) - 480) / 7;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265 + 80 + model1.width;
                model7.y = 140 + 80 + model1.height;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = ((par1.width - 405) - 480) / 7;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265 + 80 * 2 + (model1.width * 2);
                model8.y = 140 + 80 + model1.height;
                model8.height = ((par1.height - 280) - 160) / 3;
                model8.width = ((par1.width - 405) - 320) - model1.width * 4;
                model8.style = 1;
                doc.ksRectangle(model8);
                model9.x = 265 + 80 * 5 + (model1.width * 5);
                model9.y = 140 + 80 + model1.height;
                model9.height = ((par1.height - 280) - 160) / 3;
                model9.width = ((par1.width - 405) - 480) / 7;
                model9.style = 1;
                doc.ksRectangle(model9);
                model10.x = 265 + 80 * 6 + (model1.width * 6);
                model10.y = 140 + 80 + model1.height;
                model10.height = ((par1.height - 280) - 160) / 3;
                model10.width = ((par1.width - 405) - 480) / 7;
                model10.style = 1;
                doc.ksRectangle(model10);
                model11.x = 265;
                model11.y = 140 + 80 * 2 + model1.height * 2;
                model11.height = ((par1.height - 280) - 160) / 3;
                model11.width = ((par1.width - 405) - 480) / 7;
                model11.style = 1;
                doc.ksRectangle(model11);
                model12.x = 265 + 80 + (model1.width);
                model12.y = 140 + 80 * 2 + model1.height * 2;
                model12.height = ((par1.height - 280) - 160) / 3;
                model12.width = ((par1.width - 405) - 480) / 7;
                model12.style = 1;
                doc.ksRectangle(model12);
                model13.x = 265 + 80 * 2 + (model1.width * 2);
                model13.y = 140 + 80 * 2 + model1.height * 2;
                model13.height = ((par1.height - 280) - 160) / 3;
                model13.width = ((par1.width - 405) - 480) / 7;
                model13.style = 1;
                doc.ksRectangle(model13);
                model14.x = 265 + 80 * 3 + (model1.width * 3);
                model14.y = 140 + 80 * 2 + model1.height * 2;
                model14.height = ((par1.height - 280) - 160) / 3;
                model14.width = ((par1.width - 405) - 320) - model1.width * 4;
                model14.style = 1;
                doc.ksRectangle(model14);
                model15.x = 265 + 80 * 6 + (model1.width * 6);
                model15.y = 140 + 80 * 2 + model1.height * 2;
                model15.height = ((par1.height - 280) - 160) / 3;
                model15.width = ((par1.width - 405) - 480) / 7;
                model15.style = 1;
                doc.ksRectangle(model15);
            }
        }

        public static void Econom10()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);//создание фрагмента
                Zagotovka(par1); //создание заготовки
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height =((par1.height - 280) - 160) /3; //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model1.width = ((par1.width - 405) - 480) / 7; // 
                model1.style = 1;
                doc.ksRectangle(model1);
                model2.x = 265 + 80 + model1.width;
                model2.y = 140 + 80 * 2 + model1.height * 2;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = ((par1.width - 405) - 320) - model1.width * 4;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 * 4 + model1.width * 4;
                model3.y = 140 + 80 * 2 + model1.height * 2;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 480) / 7;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265 + 80 * 5 + model1.width * 5;
                model4.y = 140 + 80 * 2 + model1.height * 2;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) - 480) / 7;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80 * 6 + model1.width * 6;
                model5.y = 140;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 480) / 7;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265;
                model6.y = 140 + 80 + model1.height;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = ((par1.width - 405) - 480) / 7;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265 + 80 + model1.width;
                model7.y = 140 + 80 + model1.height;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = ((par1.width - 405) - 480) / 7;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265 + 80 * 2 + (model1.width * 2);
                model8.y = 140 + 80 + model1.height;
                model8.height = ((par1.height - 280) - 160) / 3;
                model8.width = ((par1.width - 405) - 320) - model1.width * 4;
                model8.style = 1;
                doc.ksRectangle(model8);
                model9.x = 265 + 80 * 5 + (model1.width * 5);
                model9.y = 140 + 80 + model1.height;
                model9.height = ((par1.height - 280) - 160) / 3;
                model9.width = ((par1.width - 405) - 480) / 7;
                model9.style = 1;
                doc.ksRectangle(model9);
                model10.x = 265 + 80 * 6 + (model1.width * 6);
                model10.y = 140 + 80 + model1.height;
                model10.height = ((par1.height - 280) - 160) / 3;
                model10.width = ((par1.width - 405) - 480) / 7;
                model10.style = 1;
                doc.ksRectangle(model10);
                model11.x = 265;
                model11.y = 140 + 80 * 2 + model1.height * 2;
                model11.height = ((par1.height - 280) - 160) / 3;
                model11.width = ((par1.width - 405) - 480) / 7;
                model11.style = 1;
                doc.ksRectangle(model11);
                model12.x = 265 + 80 + (model1.width);
                model12.y = 140;
                model12.height = ((par1.height - 280) - 160) / 3;
                model12.width = ((par1.width - 405) - 480) / 7;
                model12.style = 1;
                doc.ksRectangle(model12);
                model13.x = 265 + 80 * 2 + (model1.width * 2);
                model13.y = 140;
                model13.height = ((par1.height - 280) - 160) / 3;
                model13.width = ((par1.width - 405) - 480) / 7;
                model13.style = 1;
                doc.ksRectangle(model13);
                model14.x = 265 + 80 * 3 + (model1.width * 3);
                model14.y = 140;
                model14.height = ((par1.height - 280) - 160) / 3;
                model14.width = ((par1.width - 405) - 320) - model1.width * 4;
                model14.style = 1;
                doc.ksRectangle(model14);
                model15.x = 265 + 80 * 6 + (model1.width * 6);
                model15.y = 140 + 80 * 2 + model1.height * 2;
                model15.height = ((par1.height - 280) - 160) / 3;
                model15.width = ((par1.width - 405) - 480) / 7;
                model15.style = 1;
                doc.ksRectangle(model15);
            }
        } // зеркало модели 9, стобцы отрисовываются не по порядку!(заменены элементы 1 и 3 столбика)

        public static void Econom11()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);//создание фрагмента
                Zagotovka(par1); //создание заготовки
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height =((par1.height - 280) - 160) /3; //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model1.width = ((par1.width - 405) - 480) / 7; // 
                model1.style = 1;
                doc.ksRectangle(model1); //отрисовка элемента 1
                // за основу взята модель 8 элементы 1-5-6-10-11-15 остаются неизменными
                model2.x = 265 + 80 + model1.width;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = (((par1.width - 405) - 320) - (model1.width * 3)) / 2;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 * 2 + model1.width + model2.width;
                model3.y = 140;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 480) / 7;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265 + 80 * 3 + model1.width * 2 + model2.width;
                model4.y = 140;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = (((par1.width - 405) - 320) - (model1.width * 3)) / 2;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80 * 4 + model1.width * 2 + model2.width * 2;
                model5.y = 140;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 480) / 7;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265;
                model6.y = 140 + 80 + model1.height;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = ((par1.width - 405) - 480) / 7;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265 + 80 + model1.width;
                model7.y = 140 + 80 + model1.height;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = (((par1.width - 405) - 320) - (model1.width * 3)) / 2;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265 + 80 * 2 + model1.width + model2.width;
                model8.y = 140 + 80 + model1.height;
                model8.height = ((par1.height - 280) - 160) / 3;
                model8.width = ((par1.width - 405) - 480) / 7;
                model8.style = 1;
                doc.ksRectangle(model8);
                model9.x = 265 + 80 * 3 + model1.width * 2 + model2.width;
                model9.y = 140 + 80 + model1.height;
                model9.height = ((par1.height - 280) - 160) / 3;
                model9.width = (((par1.width - 405) - 320) - (model1.width * 3)) / 2;
                model9.style = 1;
                doc.ksRectangle(model9);
                model10.x = 265 + 80 * 4 + model1.width * 2 + model2.width * 2;
                model10.y = 140 + 80 + model1.height;
                model10.height = ((par1.height - 280) - 160) / 3;
                model10.width = ((par1.width - 405) - 480) / 7;
                model10.style = 1;
                doc.ksRectangle(model10);
                model11.x = 265;
                model11.y = 140 + 80 * 2 + model1.height * 2;
                model11.height = ((par1.height - 280) - 160) / 3;
                model11.width = ((par1.width - 405) - 480) / 7;
                model11.style = 1;
                doc.ksRectangle(model11);
                model12.x = 265 + 80 + (model1.width);
                model12.y = 140 + 80 * 2 + model1.height * 2;
                model12.height = ((par1.height - 280) - 160) / 3;
                model12.width = (((par1.width - 405) - 320) - (model1.width * 3)) / 2;
                model12.style = 1;
                doc.ksRectangle(model12);
                model13.x = 265 + 80 * 2 + model1.width + model2.width;
                model13.y = 140 + 80 * 2 + model1.height * 2;
                model13.height = ((par1.height - 280) - 160) / 3;
                model13.width = ((par1.width - 405) - 480) / 7;
                model13.style = 1;
                doc.ksRectangle(model13);
                model14.x = 265 + 80 * 3 + model1.width * 2 + model2.width;
                model14.y = 140 + 80 * 2 + model1.height * 2;
                model14.height = ((par1.height - 280) - 160) / 3;
                model14.width = (((par1.width - 405) - 320) - (model1.width * 3)) / 2;
                model14.style = 1;
                doc.ksRectangle(model14);
                model15.x = 265 + 80 * 4 + model1.width * 2 + model2.width * 2;
                model15.y = 140 + 80 * 2 + model1.height * 2;
                model15.height = ((par1.height - 280) - 160) / 3;
                model15.width = ((par1.width - 405) - 480) / 7;
                model15.style = 1;
                doc.ksRectangle(model15);
            }
        }

        public static void Econom12()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);//создание фрагмента
                Zagotovka(par1); //создание заготовки
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height =((par1.height - 280) - 160) /3;
                model1.width = ((par1.width - 405) - 480) / 7; // 
                model1.style = 1;
                doc.ksRectangle(model1); //отрисовка элемента 1
                // основа модель 8 с 9 по 13 элементы объеденены в один элемент
                model2.x = 265 + 80 + model1.width;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = ((par1.width - 405) - 480) / 7;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 * 2 + model1.width * 2;
                model3.y = 140;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 480) / 7;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265 + 80 * 3 + model1.width * 3;
                model4.y = 140;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) - 480) / 7;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80 * 4 + model1.width * 4;
                model5.y = 140;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 480) / 7;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265 + 80 * 5 + model1.width * 5;
                model6.y = 140;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = ((par1.width - 405) - 480) / 7;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265 + 80 * 6 + model1.width * 6;
                model7.y = 140;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = ((par1.width - 405) - 480) / 7;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265;
                model8.y = 140 + 80 + model1.height;
                model8.height = ((par1.height - 280) - 160) / 3;
                model8.width = ((par1.width - 405) - 480) / 7;
                model8.style = 1;
                doc.ksRectangle(model8);
                model9.x = 265 + 80 + (model1.width);
                model9.y = 140 + 80 + model1.height;
                model9.height = ((par1.height - 280) - 160) / 3;
                model9.width = ((par1.width - 405) - 160 - model1.width * 2);
                model9.style = 1;
                doc.ksRectangle(model9);
                model14.x = 265 + 80 * 6 + (model1.width * 6);
                model14.y = 140 + 80 + model1.height;
                model14.height = ((par1.height - 280) - 160) / 3;
                model14.width = ((par1.width - 405) - 480) / 7;
                model14.style = 1;
                doc.ksRectangle(model14);
                model15.x = 265;
                model15.y = 140 + 80 * 2 + model1.height * 2;
                model15.height = ((par1.height - 280) - 160) / 3;
                model15.width = ((par1.width - 405) - 480) / 7;
                model15.style = 1;
                doc.ksRectangle(model15);
                model16.x = 265 + 80 + (model1.width);
                model16.y = 140 + 80 * 2 + model1.height * 2;
                model16.height = ((par1.height - 280) - 160) / 3;
                model16.width = ((par1.width - 405) - 480) / 7;
                model16.style = 1;
                doc.ksRectangle(model16);
                model17.x = 265 + 80 * 2 + (model1.width * 2);
                model17.y = 140 + 80 * 2 + model1.height * 2;
                model17.height = ((par1.height - 280) - 160) / 3;
                model17.width = ((par1.width - 405) - 480) / 7;
                model17.style = 1;
                doc.ksRectangle(model17);
                model18.x = 265 + 80 * 3 + (model1.width * 3);
                model18.y = 140 + 80 * 2 + model1.height * 2;
                model18.height = ((par1.height - 280) - 160) / 3;
                model18.width = ((par1.width - 405) - 480) / 7;
                model18.style = 1;
                doc.ksRectangle(model18);
                model19.x = 265 + 80 * 4 + (model1.width * 4);
                model19.y = 140 + 80 * 2 + model1.height * 2;
                model19.height = ((par1.height - 280) - 160) / 3;
                model19.width = ((par1.width - 405) - 480) / 7;
                model19.style = 1;
                doc.ksRectangle(model19);
                model20.x = 265 + 80 * 5 + (model1.width * 5);
                model20.y = 140 + 80 * 2 + model1.height * 2;
                model20.height = ((par1.height - 280) - 160) / 3;
                model20.width = ((par1.width - 405) - 480) / 7;
                model20.style = 1;
                doc.ksRectangle(model20);
                model21.x = 265 + 80 * 6 + (model1.width * 6);
                model21.y = 140 + 80 * 2 + model1.height * 2;
                model21.height = ((par1.height - 280) - 160) / 3;
                model21.width = ((par1.width - 405) - 480) / 7;
                model21.style = 1;
                doc.ksRectangle(model21);
            }
        }

        public static void Econom13()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                //создание фрагмента
                Zagotovka(par1); //создание заготовки
                model2.width = ((par1.width - 405) - 480) / 7;
                model2.x = 265 + 80 * 4 + model2.width * 4;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.style = 1;
                doc.ksRectangle(model2);
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height =((par1.height - 280) - 160) /3; //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model1.width = ((par1.width - 405) / 2) + model2.width / 2; // 
                model1.style = 1;
                doc.ksRectangle(model1); //отрисовка элемента 1
                // за основу взята все таже многострадальная модель 8 =)
                model3.x = 265 + 80 * 2 + model2.width + model1.width;
                model3.y = 140;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 160) - model2.width - model1.width;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265;
                model4.y = 140 + 80 + model1.height;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) / 2) - (model2.width / 2) - 80;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80 * 3 + (model2.width * 3);
                model5.y = 140 + 80 + model1.height;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 480) / 7;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265 + 80 * 2 + model5.width + model4.width;
                model6.y = 140 + 80 + model1.height;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = ((par1.width - 405) - 160) - model2.width - model4.width;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265;
                model7.y = 140 + 80 * 2 + model1.height * 2;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = ((par1.width - 405) - 160) - model2.width - model1.width;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265 + 80 + (model7.width);
                model8.y = 140 + 80 * 2 + model1.height * 2;
                model8.height = ((par1.height - 280) - 160) / 3;
                model8.width = ((par1.width - 405) - 480) / 7;
                model8.style = 1;
                doc.ksRectangle(model8);
                model9.x = 265 + 80 * 2 + (model7.width + model8.width);
                model9.y = 140 + 80 * 2 + model1.height * 2;
                model9.height = ((par1.height - 280) - 160) / 3;
                model9.width = ((par1.width - 405) / 2) + model2.width / 2;
                model9.style = 1;
                doc.ksRectangle(model9);
            }
        }

        public static void Econom14()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                //создание фрагмента
                Zagotovka(par1); //создание заготовки
                model2.width = ((par1.width - 405) - 480) / 7;
                model2.x = 265 + 80 * 2 + model2.width * 2;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.style = 1;
                doc.ksRectangle(model2);
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height =((par1.height - 280) - 160) /3; //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model1.width = ((par1.width - 405) / 2) - model2.width - 160 - model2.width / 2; // 
                model1.style = 1;
                doc.ksRectangle(model1); //отрисовка элемента 1
                // зеркало модели 13
                model3.x = 265 + 80 * 2 + model2.width + model1.width;
                model3.y = 140;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) / 2) + model2.width / 2;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265;
                model4.y = 140 + 80 + model1.height;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) / 2) - (model2.width / 2) - 80;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80 * 3 + (model2.width * 3);
                model5.y = 140 + 80 + model1.height;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 480) / 7;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265 + 80 * 2 + model5.width + model4.width;
                model6.y = 140 + 80 + model1.height;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = ((par1.width - 405) - 160) - model2.width - model4.width;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265;
                model7.y = 140 + 80 * 2 + model1.height * 2;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = ((par1.width - 405) / 2) + model2.width / 2;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265 + 80 + (model7.width);
                model8.y = 140 + 80 * 2 + model1.height * 2;
                model8.height = ((par1.height - 280) - 160) / 3;
                model8.width = ((par1.width - 405) - 480) / 7;
                model8.style = 1;
                doc.ksRectangle(model8);
                model9.x = 265 + 80 * 2 + (model7.width + model8.width);
                model9.y = 140 + 80 * 2 + model1.height * 2;
                model9.height = ((par1.height - 280) - 160) / 3;
                model9.width = ((par1.width - 405) - 160) - model2.width - model3.width;
                model9.style = 1;
                doc.ksRectangle(model9);
            }
        } //отрисовка не по порядку!

        public static void Econom15()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);//создание фрагмента
                Zagotovka(par1); //создание заготовки
                model2.width = ((par1.width - 405) - 480) / 7;
                model2.x = 265 + 80 * 3 + (model2.width * 3);
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.style = 1;
                doc.ksRectangle(model2);
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height =((par1.height - 280) - 160) /3; //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model1.width = ((par1.width - 405) / 2) - (model2.width / 2) - 80; // 
                model1.style = 1;
                doc.ksRectangle(model1); //отрисовка элемента 1
                model3.x = 265 + 80 * 2 + model2.width + model1.width;
                model3.y = 140;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) / 2) - (model2.width / 2) - 80; // 
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265;
                model4.y = 140 + 80 + model1.height;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) / 2) - (model2.width / 2) - 80;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80 * 3 + (model2.width * 3);
                model5.y = 140 + 80 + model1.height;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 480) / 7;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265 + 80 * 2 + model5.width + model4.width;
                model6.y = 140 + 80 + model1.height;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = ((par1.width - 405) - 160) - model2.width - model4.width;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265;
                model7.y = 140 + 80 * 2 + model1.height * 2;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = ((par1.width - 405) / 2) - (model2.width / 2) - 80;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265 + 80 * 3 + (model2.width * 3);
                model8.y = 140 + 80 * 2 + model1.height * 2;
                model8.height = ((par1.height - 280) - 160) / 3;
                model8.width = ((par1.width - 405) - 480) / 7;
                model8.style = 1;
                doc.ksRectangle(model8);
                model9.x = 265 + 80 * 2 + (model7.width + model8.width);
                model9.y = 140 + 80 * 2 + model1.height * 2;
                model9.height = ((par1.height - 280) - 160) / 3;
                model9.width = ((par1.width - 405) - 160) - model2.width - model4.width;
                model9.style = 1;
                doc.ksRectangle(model9);
            }
        }

        public static void Econom16()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                //создание фрагмента
                Zagotovka(par1); //создание заготовки
                model1.x = 265; //отступы рисунка на заготовке
                model1.y = 140;
                model1.height = ((par1.height - 280) - 160) / 3;
                model1.width = ((par1.width - 405) - 240) / 4;
                model1.style = 1;
                doc.ksRectangle(model1);
                model2.x = 265 + 80 + model1.width;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = ((par1.width - 405) - 240) / 4;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 * 2 + model1.width * 2;
                model3.y = 140;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 240) / 4;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265 + 80 * 3 + model1.width * 3;
                model4.y = 140;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) - 240) / 4;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265;
                model5.y = 140 + 80 + model1.height;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 240) / 4;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265 + 80 + (model1.width);
                model6.y = 140 + 80 + model1.height;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = ((par1.width - 405) - 240) / 4;
                model6.style = 1;
                doc.ksRectangle(model6);
                model7.x = 265 + 80 * 2 + (model1.width * 2);
                model7.y = 140 + 80 + model1.height;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = ((par1.width - 405) - 240) / 4;
                model7.style = 1;
                doc.ksRectangle(model7);
                model8.x = 265 + 80 * 3 + (model1.width * 3);
                model8.y = 140 + 80 + model1.height;
                model8.height = ((par1.height - 280) - 160) / 3;
                model8.width = ((par1.width - 405) - 240) / 4;
                model8.style = 1;
                doc.ksRectangle(model8);
                model9.x = 265;
                model9.y = 140 + 80 * 2 + model1.height * 2;
                model9.height = ((par1.height - 280) - 160) / 3;
                model9.width = ((par1.width - 405) - 240) / 4;
                model9.style = 1;
                doc.ksRectangle(model9);
                model10.x = 265 + 80 + (model1.width);
                model10.y = 140 + 80 * 2 + model1.height * 2;
                model10.height = ((par1.height - 280) - 160) / 3;
                model10.width = ((par1.width - 405) - 240) / 4;
                model10.style = 1;
                doc.ksRectangle(model10);
                model11.x = 265 + 80 * 2 + (model1.width * 2);
                model11.y = 140 + 80 * 2 + model1.height * 2;
                model11.height = ((par1.height - 280) - 160) / 3;
                model11.width = ((par1.width - 405) - 240) / 4;
                model11.style = 1;
                doc.ksRectangle(model11);
                model12.x = 265 + 80 * 3 + (model1.width * 3);
                model12.y = 140 + 80 * 2 + model1.height * 2;
                model12.height = ((par1.height - 280) - 160) / 3;
                model12.width = ((par1.width - 405) - 240) / 4;
                model12.style = 1;
                doc.ksRectangle(model12);
            }
        }

        public static void Econom17()
        {
            doc = (ksDocument2D) kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);//создание фрагмента
                Zagotovka(par1); //создание заготовки
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height =(par1.height -280); //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model1.width = ((par1.width - 405) - 480) / 5; // 
                model1.style = 1;
                doc.ksRectangle(model1); //отрисовка элемента 1
                model2.x = 265 + 80 + model1.width;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = ((par1.width - 405) - 160) - model1.width - 360;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 + model1.width;
                model3.y = 140 + 80 * 2 + model2.height * 2;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 160) - model1.width - 360;
                model3.style = 1;
                doc.ksRectangle(model3);
                Point1.x = 265 + 80 + model1.width; 
                Point1.y = 140 + 80 + model2.height; //Point1 точка начала отрезка
                Point2.x = model2.width + 80 + 265 + 80 + model1.width; //
                Point2.y = 140 + 80 + model2.height; //Point2 точка конца отрезка                
                doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                doc.ksLineSeg(Point1.x, Point1.y + model2.height, Point2.x, Point1.y + model2.height, 1);
                doc.ksLineSeg(Point1.x, Point1.y, Point1.x, Point1.y + model2.height, 1);
                doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2, model2.height / 2, Point2.x,
                    Point1.y, Point2.x, Point1.y + model2.height, 1, 1); //xc, yc, rad, x1, y1, x2, y2, direction, style
                //xc, yc-координаты центра дуги,
                //rad -радиус дуги,
                //x1, y1 -координаты начальной точки дуги,
                //x2, y2-координаты конечной точки дуги,
                //direction-направление отрисовки дуги:1 - против часовой стрелки,-1 - по часовой стрелке,
                //style-стиль линии.
                //Элемент 4
                reference curve1 = doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, Point2.x, Point1.y, Point2.x, Point1.y + model2.height, 1, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, par1.width - 140, 140,
                    1); // x1, y1, x2, y2, стиль линии
                doc.ksLineSeg(par1.width - 140, 140, par1.width - 140, (par1.height / 2) - 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, model1.width + 160 + model2.width + 265,
                    ((par1.height) / 2) - (model2.height / 2) - 80, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    par1.width - 140, 140 + 80 * 2 + model2.height * 3, 1);
                doc.ksLineSeg(par1.width - 140, 140 + 80 * 2 + model2.height * 3, par1.width - 140,
                    (par1.height / 2) + 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    model1.width + 160 + model2.width + 265, ((par1.height) / 2) + (model2.height / 2) + 80, 1);

                reference auxcircle = doc.ksCircle(265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, 1);

                mat.ksIntersectLinSCir(par1.width, par1.height / 2 - 40, 265 + model1.width + 160 + model2.width, par1.height / 2 - 40,
                    265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width - 140, par1.height / 2 - 40, par.x, par.y, 1);
                double px1 = par.x;
                double py1 = par.y;

                mat.ksIntersectLinSCir(par1.width, par1.height / 2 + 40, 265 + model1.width + 160 + model2.width, par1.height / 2 + 40,
                    265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width - 140, par1.height / 2 + 40, par.x, par.y, 1);
                double px2 = par.x;
                double py2 = par.y;

                doc.ksDeleteObj(auxcircle);
                doc.ksTrimmCurve(curve1, Point2.x, Point1.y, px1, py1, px1, py1, 0);
                doc.ksTrimmCurve(curve1, px2, py2, Point2.x, Point1.y + model2.height, Point2.x, Point1.y + model2.height, 1);
            }
        }

        public static void Econom18()
        {
            doc = (ksDocument2D) kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                Zagotovka(par1);
                model1.x = 265;
                model1.y = 140;
                model1.height = (par1.height - 280);
                model1.width = ((par1.width - 405) - 480) / 5;
                model1.style = 1;
                doc.ksRectangle(model1);
                model2.x = 265 + 80 + model1.width;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = ((par1.width - 405) - 160) - model1.width - 360;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 + model1.width;
                model3.y = 140 + 80 * 2 + model2.height * 2;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 160) - model1.width - 360;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265 + 80 + model1.width;
                model4.y = 140 + 80 + model2.height;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) - 160) - model1.width - par1.width / 4;
                model4.style = 1;
                doc.ksRectangle(model4);
                Point1.x = 265 + 80 + model1.width; 
                Point1.y = 140 + 80 + model2.height;
                Point2.x = model2.width + 80 + 265 + 80 + model1.width;
                Point2.y = 140 + 80 + model2.height;          
                doc.ksLineSeg(Point1.x + model4.width + 80, Point1.y, Point2.x, Point2.y, 1);
                doc.ksLineSeg(Point1.x + model4.width + 80, Point1.y + model2.height, Point2.x,
                    Point1.y + model2.height, 1);
                doc.ksLineSeg(Point1.x + model4.width + 80, Point1.y, Point1.x + model4.width + 80,
                    Point1.y + model2.height, 1);
                doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2, model2.height / 2, Point2.x,
                    Point1.y, Point2.x, Point1.y + model2.height, 1, 1); 
                reference curve1 = doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, Point2.x, Point1.y, Point2.x, Point1.y + model2.height, 1, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, par1.width - 140, 140, 1);
                doc.ksLineSeg(par1.width - 140, 140, par1.width - 140, (par1.height / 2) - 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, model1.width + 160 + model2.width + 265,
                    ((par1.height) / 2) - (model2.height / 2) - 80, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    par1.width - 140, 140 + 80 * 2 + model2.height * 3, 1);
                doc.ksLineSeg(par1.width - 140, 140 + 80 * 2 + model2.height * 3, par1.width - 140,
                    (par1.height / 2) + 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    model1.width + 160 + model2.width + 265, ((par1.height) / 2) + (model2.height / 2) + 80, 1);

                reference auxcircle = doc.ksCircle(265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, 1);

                mat.ksIntersectLinSCir(par1.width, par1.height / 2 - 40, 265 + model1.width + 160 + model2.width, par1.height / 2 - 40,
                    265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width - 140, par1.height / 2 - 40, par.x, par.y, 1);
                double px1 = par.x;
                double py1 = par.y;

                mat.ksIntersectLinSCir(par1.width, par1.height / 2 + 40, 265 + model1.width + 160 + model2.width, par1.height / 2 + 40,
                    265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width - 140, par1.height / 2 + 40, par.x, par.y, 1);
                double px2 = par.x;
                double py2 = par.y;

                doc.ksDeleteObj(auxcircle);
                doc.ksTrimmCurve(curve1, Point2.x, Point1.y, px1, py1, px1, py1, 0);
                doc.ksTrimmCurve(curve1, px2, py2, Point2.x, Point1.y + model2.height, Point2.x, Point1.y + model2.height, 1);
            }
        }

        public static void Econom19()
        {
            doc = (ksDocument2D) kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                Zagotovka(par1);
                model1.x = 265; 
                model1.y = 140;
                model1.height = ((par1.height - 280) - 160) / 3;
                model1.width = ((par1.width - 405) - 480) / 5;
                model1.style = 1;
                doc.ksRectangle(model1);
                model4.x = 265;
                model4.y = 140 + 80 + model1.height;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) - 480) / 5; 
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265;
                model5.y = 140 + 80 * 2 + model1.height * 2;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = ((par1.width - 405) - 480) / 5;
                model5.style = 1;
                doc.ksRectangle(model5);
                model2.x = 265 + 80 + model1.width;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = ((par1.width - 405) - 160) - model1.width - 360;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265 + 80 + model1.width;
                model3.y = 140 + 80 * 2 + model2.height * 2;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = ((par1.width - 405) - 160) - model1.width - 360;
                model3.style = 1;
                doc.ksRectangle(model3);
                Point1.x = 265 + 80 + model1.width; 
                Point1.y = 140 + 80 + model2.height;
                Point2.x = model2.width + 80 + 265 + 80 + model1.width;
                Point2.y = 140 + 80 + model2.height;                
                doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                doc.ksLineSeg(Point1.x, Point1.y + model2.height, Point2.x, Point1.y + model2.height, 1);
                doc.ksLineSeg(Point1.x, Point1.y, Point1.x, Point1.y + model2.height, 1);
                doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2, model2.height / 2, Point2.x,
                    Point1.y, Point2.x, Point1.y + model2.height, 1, 1); //xc, yc, rad, x1, y1, x2, y2, direction, style
                reference curve1 = doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, Point2.x, Point1.y, Point2.x, Point1.y + model2.height, 1, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, par1.width - 140, 140, 1);// x1, y1, x2, y2, стиль линии
                doc.ksLineSeg(par1.width - 140, 140, par1.width - 140, (par1.height / 2) - 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, model1.width + 160 + model2.width + 265,
                    ((par1.height) / 2) - (model2.height / 2) - 80, 1);
                
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    par1.width - 140, 140 + 80 * 2 + model2.height * 3, 1);
                doc.ksLineSeg(par1.width - 140, 140 + 80 * 2 + model2.height * 3, par1.width - 140,
                    (par1.height / 2) + 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    model1.width + 160 + model2.width + 265, ((par1.height) / 2) + (model2.height / 2) + 80, 1);
                reference auxcircle = doc.ksCircle(265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, 1);

                mat.ksIntersectLinSCir(par1.width, par1.height / 2 - 40, 265 + model1.width + 160 + model2.width, par1.height / 2 - 40,
                    265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width - 140, par1.height / 2 - 40, par.x, par.y, 1);
                double px1 = par.x;
                double py1 = par.y;

                mat.ksIntersectLinSCir(par1.width, par1.height / 2 + 40, 265 + model1.width + 160 + model2.width, par1.height / 2 + 40,
                    265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width - 140, par1.height / 2 + 40, par.x, par.y, 1);
                double px2 = par.x;
                double py2 = par.y;

                doc.ksDeleteObj(auxcircle);
                doc.ksTrimmCurve(curve1, Point2.x, Point1.y, px1, py1, px1, py1, 0);
                doc.ksTrimmCurve(curve1, px2, py2, Point2.x, Point1.y + model2.height, Point2.x, Point1.y + model2.height, 1);
            }
        }

        public static void Econom20()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D) kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                Zagotovka(par1);
                model1.x = 265;
                model1.y = 140;
                model1.height = par1.height / 10;
                model1.width = (par1.height / 10) * 3;
                model1.style = 1;
                doc.ksRectangle(model1);
                model2.x = 265;
                model2.y = par1.height - 140 - model1.height;
                model2.height = par1.height / 10;
                model2.width = (par1.height / 10) * 3;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265;
                model3.y = 140 + 80 + model1.height;
                model3.height = par1.height - 280 - 80 * 2 - model1.height * 2;
                model3.width = (par1.width + 400) / 4;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265 + model1.width + 80;
                model4.y = 140;
                model4.height = model1.height;
                model4.width = (par1.width + 100) / 3;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + model1.width + 80;
                model5.y = par1.height - 140 - model1.height;
                model5.height = model1.height;
                model5.width = (par1.width + 100) / 3;
                model5.style = 1;
                doc.ksRectangle(model5);

                doc.ksLineSeg(265 + model3.width + 80, 140 + model4.height + 80, 265 + model3.width + 80,
                    par1.height - 140 - model5.height - 80, 1);
                doc.ksLineSeg(265 + model3.width + 80, 140 + model4.height + 80, (par1.width * 3) / 4, 140 + model4.height + 80, 1);
                doc.ksLineSeg(265 + model3.width + 80, par1.height - 140 - model5.height - 80, (par1.width * 3) / 4,
                    par1.height - 140 - model5.height - 80, 1);

                doc.ksLineSeg(265 + 80 * 2 + model1.width + model4.width, 140,
                    265 + 80 * 2 + model1.width + model4.width, 140 + model1.height, 1);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model4.width, 140, par1.width - 140, 140, 1);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model4.width, 140 + model1.height, (par1.width * 3) / 4,
                    140 + model1.height, 1);
                doc.ksLineSeg(par1.width - 140, 140, par1.width - 140, par1.height / 2 - 40, 1);

                doc.ksLineSeg(265 + 80 * 2 + model1.width + model4.width, par1.height - 140,
                    265 + 80 * 2 + model1.width + model4.width, par1.height - 140 - model5.height, 1);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model4.width, par1.height - 140, par1.width - 140,
                    par1.height - 140, 1);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model4.width, par1.height - 140 - model5.height,
                    (par1.width * 3) / 4, par1.height - 140 - model5.height, 1);
                doc.ksLineSeg(par1.width - 140, par1.height - 140, par1.width - 140, par1.height / 2 + 40, 1);

                double rad1 = (par1.height - 140 * 2 - model1.height * 2 - 80 * 2) / 2;
                doc.ksArcBy3Points((par1.width * 3) / 4, 140 + model1.height + 80,
                    ((par1.width * 3) / 4) + rad1, par1.height / 2,
                    (par1.width * 3) / 4, par1.height - 140 - model5.height - 80, 1);

                reference curve1 = doc.ksArcBy3Points((par1.width * 3) / 4, 140 + model1.height, ((par1.width * 3) / 4) + rad1 + 80, par1.height / 2,
                    (par1.width * 3) / 4, par1.height - 140 - model1.height, 1);
                reference auxcircle = doc.ksCircle((par1.width * 3) / 4, par1.height / 2, rad1 + 80, 1);

                mat.ksIntersectLinSCir(par1.width, par1.height / 2 - 40, (par1.width * 3) / 4, par1.height / 2 - 40,
                    (par1.width * 3) / 4, par1.height / 2, rad1 + 80, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width-140,par1.height/2-40, par.x, par.y, 1);
                double px1 = par.x;
                double py1 = par.y;

                mat.ksIntersectLinSCir(par1.width, par1.height / 2 + 40, (par1.width * 3) / 4, par1.height / 2 + 40,
                    (par1.width * 3) / 4, par1.height / 2, rad1 + 80, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width - 140, par1.height / 2 + 40, par.x, par.y, 1);
                double px2 = par.x;
                double py2 = par.y;

                doc.ksDeleteObj(auxcircle);
                doc.ksTrimmCurve(curve1, (par1.width * 3) / 4, 140 + model1.height, px1, py1, px1, py1, 0);
                doc.ksTrimmCurve(curve1, px2, py2, (par1.width * 3) / 4, par1.height - 140 - model1.height,
                    (par1.width * 3) / 4, par1.height - 140 - model1.height, 1);

            }
        }

        public static void Econom21()
        {
            doc = (ksDocument2D) kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 265;
                    model1.y = 140;
                    model1.height = (par1.height / 2 - 180);
                    model1.width = ((par1.width - 405) - 160) / 3;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    model2.x = 265;
                    model2.y = (par1.height / 2 + 40);
                    model2.height = (par1.height / 2 - 180);
                    model2.width = ((par1.width - 405) - 160) / 3;
                    model2.style = 1;
                    doc.ksRectangle(model2);

                    double rad1 = par1.height / 2 - 140;
                    reference auxcircle = doc.ksCircle(par1.width - 140 - rad1, par1.height / 2, rad1, 1);//вспомогательная окружность для построения
                    reference auxline1 = doc.ksLine(0, par1.height / 2 + 40, 180);//линии 40 усечения центральной части или начальные точки дуг
                    reference auxline2 = doc.ksLine(0, par1.height/2 - 40, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - 140 - rad1/2, 180);//линии 140-радиус конечные точки дуг
                    reference auxline4 = doc.ksLine(0, 140 + rad1 / 2, 180);

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height / 2 + 40, 180,arr);
                    GetPoint(arr,par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height / 2 - 40, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height - 140 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, 140 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference auxlinexcyc1 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, 30);//получаем центры крайних дуг(точки расположены под углом 30 градсов и на расстоянии двух радиусов)
                    reference auxlinexcyc2 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, -30);//строим 2 прямые из цетра главной окружности под углом 30 и -30 градусов и еще две из отступов 140 точки пересечения и будут центрами
                    reference auxline5 = doc.ksLine(0, par1.height - 140, 180);
                    reference auxline6 = doc.ksLine(0, 140, 180);
                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, 30, 0, par1.height - 140, 180,arr);
                    GetPoint(arr,par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;
                    
                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, -30, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 1);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 1);
                    reference auxlineS1 = doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, 6);
                    reference auxlineS2 = doc.ksLineSeg(265 + model1.width + 80,140, par1.width,140, 6);
                    mat.ksIntersectLinSCir(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, pxc1, pyc1, rad1, arr);
                    GetPoint(arr,par);
                    double px5 = par.x;
                    double py5 = par.y;
                    doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, px5, py5, 1);

                    mat.ksIntersectLinSCir(265 + model1.width + 80, 140, par1.width, 140, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr,par);
                    double px6 = par.x;
                    double py6 = par.y;
                    doc.ksLineSeg(265 + model1.width + 80,140, px6, py6, 1);

                    doc.ksLineSeg(265 + model1.width + 80, 140, 265 + model1.width + 80,140+ model1.height, 1);//достраиваем чертеж
                    doc.ksLineSeg(265 + model1.width + 80, model1.height + 140, px2, py2, 1);
                    doc.ksLineSeg(265 + model1.width + 80, py1, px1, py1, 1);
                    doc.ksLineSeg(265 + model1.width + 80, py1, 265 + model1.width + 80, par1.height - 140, 1);
                    doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, px5, py5, 1);

                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px1, py1, px3, py3, 1, 1);//построение центральных дуг
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px2, py2, px4, py4, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px3, py3, px5, py5, -1, 1);//построение крайних дуг
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px4, py4, px6, py6, 1, 1);

                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxline5);
                    doc.ksDeleteObj(auxline6);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);
                    //Построение следующее строим окружность вспомогательную, строим линии для пересечения (ищем точки начальные и конечные далее записываем их)
                    //строим из цетра окружности 2 прямые под углом 30 и -30 градусов соответсвенно и еще 2 прямые на отступах 140, полученные точки пересечения
                    //и будут центрами 2 других вcпомогательных окружностей из которых построим дуги...
                }
            }
        }

        public static void Econom22()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - 140;
                    reference auxcircle1 = doc.ksCircle(par1.width - 140 - rad1, par1.height / 2, rad1, 6);
                    reference auxlinexcyc1 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, 30);
                    reference auxlinexcyc2 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, -30);
                    reference auxline1 = doc.ksLine(0, par1.height - 140 - rad1 / 2, 180);//линии 140-радиус конечные точки дуг
                    reference auxline2 = doc.ksLine(0, 140 + rad1 / 2, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - 140, 180);//крайние линии
                    reference auxline4 = doc.ksLine(0, 140, 180);
                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height - 140 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, 140 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, 30, 0, par1.height - 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, -30, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 6);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 6);
                    reference auxlineS1 = doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, 6);
                    reference auxlineS2 = doc.ksLineSeg(265 + model1.width + 80, 140, par1.width, 140, 6);
                    mat.ksIntersectLinSCir(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectLinSCir(265 + model1.width + 80, 140, par1.width, 140, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px1, py1, px2, py2, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px1, py1, px3, py3, -1, 1);
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px2, py2, px4, py4, 1, 1);
                    doc.ksEndGroup();

                    doc.ksLineSeg(par1.width / 2.5, 140, px4, py4, 1);
                    doc.ksLineSeg(par1.width / 2.5, par1.height-140, px3, py3, 1);
                    doc.ksCopyObj(grpCurve, px4, py4, par1.width / 2.5, 140, 1, 0);
                    doc.ksCopyObj(grpCurve, px4, py4, par1.width / 2.5-80, 140, 1, 0);
                    doc.ksLineSeg(265, 140, par1.width / 2.5 - 80, 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5 - 80, par1.height - 140, 1);

                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle1);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);
                }
            }
        }

        public static void Econom23()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - 140;
                    reference auxcircle1 = doc.ksCircle(par1.width - 140 - rad1, par1.height / 2, rad1, 6);
                    reference auxlinexcyc1 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, 30);
                    reference auxlinexcyc2 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, -30);
                    reference auxline1 = doc.ksLine(0, par1.height - 140 - rad1 / 2, 180);//линии 140-радиус конечные точки дуг
                    reference auxline2 = doc.ksLine(0, 140 + rad1 / 2, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - 140, 180);//крайние линии
                    reference auxline4 = doc.ksLine(0, 140, 180);
                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height - 140 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, 140 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, 30, 0, par1.height - 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, -30, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 6);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 6);
                    reference auxlineS1 = doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, 6);
                    reference auxlineS2 = doc.ksLineSeg(265 + model1.width + 80, 140, par1.width, 140, 6);
                    mat.ksIntersectLinSCir(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectLinSCir(265 + model1.width + 80, 140, par1.width, 140, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px1, py1, px2, py2, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px1, py1, px3, py3, -1, 1);
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px2, py2, px4, py4, 1, 1);
                    doc.ksEndGroup();

                    doc.ksLineSeg(par1.width / 2.5, 140, px4, py4, 1);
                    doc.ksLineSeg(par1.width / 2.5, par1.height - 140, px3, py3, 1);
                    doc.ksCopyObj(grpCurve, px4, py4, par1.width / 2.5,par1.height-140, 1, 180);
                    doc.ksCopyObj(grpCurve, px4, py4, par1.width / 2.5 - 80, par1.height - 140, 1, 180);
                    doc.ksLineSeg(265, 140, par1.width / 2.5 - 80, 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5 - 80, par1.height - 140, 1);

                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle1);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);
                }
            }
        }

        public static void Econom24()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - 140;
                    reference auxcircle1 = doc.ksCircle(par1.width - 140 - rad1, par1.height / 2, rad1, 6);
                    reference auxlinexcyc1 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, 30);
                    reference auxlinexcyc2 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, -30);
                    reference auxline1 = doc.ksLine(0, par1.height - 140 - rad1 / 2, 180);//линии 140-радиус конечные точки дуг
                    reference auxline2 = doc.ksLine(0, 140 + rad1 / 2, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - 140, 180);//крайние линии
                    reference auxline4 = doc.ksLine(0, 140, 180);
                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height - 140 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, 140 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, 30, 0, par1.height - 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, -30, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 6);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 6);
                    reference auxlineS1 = doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, 6);
                    reference auxlineS2 = doc.ksLineSeg(265 + model1.width + 80, 140, par1.width, 140, 6);
                    mat.ksIntersectLinSCir(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectLinSCir(265 + model1.width + 80, 140, par1.width, 140, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px1, py1, px2, py2, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px1, py1, px3, py3, -1, 1);
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px2, py2, px4, py4, 1, 1);
                    doc.ksEndGroup();

                    reference auxline5 = doc.ksLine(par1.width / 2, 0, 90);
                    mat.ksIntersectLinLin(par1.width / 2, 0, 90, 0, par1.height - 140, 180, arr);
                    GetPoint(arr,par);
                    double px5 = par.x;
                    double py5 = par.y;
                    mat.ksIntersectLinLin(par1.width / 2, 0, 90, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double px6 = par.x;
                    double py6 = par.y;
                    doc.ksLineSeg(px6,py6, px4, py4, 1);
                    doc.ksLineSeg(px5,py5, px3, py3, 1);
                    doc.ksCopyObj(grpCurve, px4, py4, par1.width / 2, par1.height-140, 1, 180);

                    doc.ksCopyObj(grpCurve, px4, py4, par1.width / 2.5 - 80, 140, 1, 0);
                    doc.ksLineSeg(265, 140, par1.width / 2.5 - 80, 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5 - 80, par1.height - 140, 1);

                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle1);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);
                    doc.ksDeleteObj(auxline5);
                }
            }
        }

        public static void Econom25()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - 140;
                    reference auxcircle1 = doc.ksCircle(par1.width - 140 - rad1, par1.height / 2, rad1, 6);
                    reference auxlinexcyc1 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, 30);
                    reference auxlinexcyc2 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, -30);
                    reference auxline1 = doc.ksLine(0, par1.height - 140 - rad1 / 2, 180);//линии 140-радиус конечные точки дуг
                    reference auxline2 = doc.ksLine(0, 140 + rad1 / 2, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - 140, 180);//крайние линии
                    reference auxline4 = doc.ksLine(0, 140, 180);
                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height - 140 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, 140 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, 30, 0, par1.height - 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, -30, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 6);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 6);
                    reference auxlineS1 = doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, 6);
                    reference auxlineS2 = doc.ksLineSeg(265 + model1.width + 80, 140, par1.width, 140, 6);
                    mat.ksIntersectLinSCir(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectLinSCir(265 + model1.width + 80, 140, par1.width, 140, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px1, py1, px2, py2, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px1, py1, px3, py3, -1, 1);
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px2, py2, px4, py4, 1, 1);
                    doc.ksEndGroup();

                    doc.ksLineSeg(par1.width / 2.5, 140, px4, py4, 1);
                    doc.ksLineSeg(par1.width / 2.5, par1.height - 140, px3, py3, 1);
                    doc.ksCopyObj(grpCurve, px4, py4, par1.width / 2.5, 140, 1, 0);

                    reference auxline5 = doc.ksLineSeg(par1.width, par1.height / 2 + 40, par1.width - 150,
                        par1.height / 2 + 40, 6);
                    reference auxline6 = doc.ksLineSeg(par1.width, par1.height / 2 - 40, par1.width - 150,
                        par1.height / 2 - 40, 6);
                    mat.ksIntersectLinSCir(par1.width, par1.height / 2 + 40, par1.width - 150, par1.height / 2 + 40,
                        par1.width - 140 - rad1, par1.height / 2, rad1, arr);
                    GetPoint(arr, par);
                    double pxf1 = par.x;
                    double pyf1 = par.y;
                    
                    mat.ksIntersectLinSCir(par1.width, par1.height / 2 - 40, par1.width - 150, par1.height / 2 - 40,
                        par1.width - 140 - rad1, par1.height / 2, rad1, arr);
                    GetPoint(arr, par);
                    double pxf2 = par.x;
                    double pyf2 = par.y;

                    reference auxLineR = doc.ksLine(px3, py3, 90);//поиск расстояния от нижней части классики до вехней
                    mat.ksIntersectLinLin(px3, py3, 90, 0, par1.height / 2 - 40, 0, arr);
                    GetPoint(arr, par);
                    double pxd1 = par.x;
                    double pyd1 = par.y;
                    double DPoint1 = mat.ksDistancePntPnt(pxf2, pyf2, pxd1, pyd1);

                    reference grpCurve2 = doc.ksNewGroup(0);
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, pxf1, pyf1, px1, py1, 1, 1);
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, pxf2, pyf2, px2, py2, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px1, py1, px3, py3, -1, 1);
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px2, py2, px4, py4, 1, 1);
                    doc.ksEndGroup();
                    doc.ksCopyObj(grpCurve2, px4, py4, par1.width / 2.5-80, 140, 1, 0);
                    doc.ksLineSeg(265, 140, par1.width / 2.5 - 80, 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height / 2 - 40, 1);
                    doc.ksLineSeg(265, par1.height / 2 - 40, par1.width / 2.5 - 80 + DPoint1, par1.height / 2 - 40, 1);

                    doc.ksLineSeg(265, par1.height / 2 + 40, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5 - 80, par1.height - 140, 1);
                    doc.ksLineSeg(265, par1.height / 2 + 40, par1.width / 2.5 - 80 + DPoint1, par1.height / 2 + 40, 1);
                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxline5);
                    doc.ksDeleteObj(auxline6);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle1);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);
                    doc.ksDeleteObj(grpCurve2);
                    doc.ksDeleteObj(auxLineR);
                }
            }
        }

        public static void Econom26()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    reference grpRect = doc.ksNewGroup(0);
                    model1.x = 265;
                    model1.y = 140;
                    model1.height = (par1.height / 2 - 180);
                    model1.width = ((par1.width - 405) - 160) / 3;
                    model1.style = 6;
                    doc.ksRectangle(model1);
                    model2.x = 265;
                    model2.y = (par1.height / 2 + 40);
                    model2.height = (par1.height / 2 - 180);
                    model2.width = ((par1.width - 405) - 160) / 3;
                    model2.style = 6;
                    doc.ksRectangle(model2);
                    doc.ksEndGroup();

                    double rad1 = par1.height / 2 - 140;
                    reference auxcircle = doc.ksCircle(par1.width - 140 - rad1, par1.height / 2, rad1, 1);//вспомогательная окружность для построения
                    reference auxline1 = doc.ksLine(0, par1.height / 2 + 40, 180);//линии 40 усечения центральной части или начальные точки дуг
                    reference auxline2 = doc.ksLine(0, par1.height / 2 - 40, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - 140 - rad1 / 2, 180);//точки соединения дуг
                    reference auxline4 = doc.ksLine(0, 140 + rad1 / 2, 180);

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height / 2 + 40, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height / 2 - 40, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height - 140 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, 140 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference auxlinexcyc1 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, 30);//получаем центры крайних дуг(точки расположены под углом 30 градсов и на расстоянии двух радиусов)
                    reference auxlinexcyc2 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, -30);//строим 2 прямые из цетра главной окружности под углом 30 и -30 градусов и еще две из отступов 140 точки пересечения и будут центрами
                    reference auxline5 = doc.ksLine(0, par1.height - 140, 180);//линии 140-радиус конечные точки дуг
                    reference auxline6 = doc.ksLine(0, 140, 180);
                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, 30, 0, par1.height - 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, -30, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 1);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 1);
                    reference auxlineS1 = doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, 6);
                    reference auxlineS2 = doc.ksLineSeg(265 + model1.width + 80, 140, par1.width, 140, 6);
                    mat.ksIntersectLinSCir(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px5 = par.x;
                    double py5 = par.y;
                    reference auxlineS3 = doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, px5, py5, 6);

                    mat.ksIntersectLinSCir(265 + model1.width + 80, 140, par1.width, 140, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px6 = par.x;
                    double py6 = par.y;
                    reference auxlineS4 = doc.ksLineSeg(265 + model1.width + 80, 140, px6, py6, 6);

                    doc.ksLineSeg(265, 140, 265, 140 + model1.height, 1);
                    doc.ksLineSeg(265, 140 + model1.height + 80, 265, par1.height - 140, 1);
                    
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px1, py1, px3, py3, 1, 1);//построение центральных дуг
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px2, py2, px4, py4, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px3, py3, px5, py5, -1, 1);//построение крайних дуг
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px4, py4, px6, py6, 1, 1);
                    
                    //строим нижню часть накладки
                    reference auxcurve2 = doc.ksArcByPoint(240 + rad1, par1.height / 2, rad1, 240 + rad1, 140,
                        240 + rad1, par1.height - 140, 1, 6);
                    mat.ksIntersectArcLin(240 + rad1, par1.height / 2, rad1, 270, 90, 1, 0, par1.height / 2 + 40, 180,arr);
                    GetPoint(arr,par);
                    double px7 = par.x;//40е от центра точки пересечения
                    double py7 = par.y;
                    mat.ksIntersectArcLin(240 + rad1, par1.height / 2, rad1, 270, 90, 1, 0, par1.height / 2 - 40, 180, arr);
                    GetPoint(arr, par);
                    double px8 = par.x;
                    double py8 = par.y;
                    doc.ksLineSeg(px7, py7, px1, py1, 1);
                    doc.ksLineSeg(px8, py8, px2, py2, 1);
                    mat.ksIntersectArcLin(240 + rad1, par1.height / 2, rad1, 270, 90, 1, 0,
                        par1.height - 140 - rad1 / 2, 180, arr);
                    GetPoint(arr,par);
                    double px9 = par.x;//точки соединения дуг
                    double py9 = par.y;
                    mat.ksIntersectArcLin(240 + rad1, par1.height / 2, rad1, 270, 90, 1, 0,
                        140 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px10 = par.x;
                    double py10 = par.y;
                    reference auxlinexcyc3 = doc.ksLine(240 + rad1, par1.height/2, 30);
                    reference auxlinexcyc4 = doc.ksLine(240 + rad1, par1.height/2, -30);
                    mat.ksIntersectLinLin(0, par1.height - 140, 180, 240 + rad1, par1.height/2, 30, arr);
                    GetPoint(arr,par);
                    double pxc3 = par.x;
                    double pyc3 = par.y;
                    mat.ksIntersectLinLin(0, 140, 180, 240 + rad1, par1.height/2, -30, arr);
                    GetPoint(arr, par);
                    double pxc4 = par.x;
                    double pyc4 = par.y;
                    reference auxcircle4 = doc.ksCircle(pxc3, pyc3, rad1, 6);
                    reference auxcircle5 = doc.ksCircle(pxc4, pyc4, rad1, 6);
                    mat.ksIntersectCirLin(pxc3, pyc3, rad1, 0, par1.height - 140, 180, arr);
                    GetPoint(arr,par);
                    double px11 = par.x;//крайние точки
                    double py11 = par.y;
                    mat.ksIntersectCirLin(pxc4, pyc4, rad1, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double px12 = par.x;
                    double py12 = par.y;
                    doc.ksLineSeg(px11 - rad1 * 2, py11, px5, py5, 1);
                    doc.ksLineSeg(px12 - rad1 * 2, py12, px6, py6, 1);

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(240 + rad1, par1.height / 2, rad1, px7, py7, px9, py9, 1, 1);
                    doc.ksArcByPoint(240 + rad1, par1.height / 2, rad1, px8, py8, px10, py10, -1, 1);
                    doc.ksArcByPoint(pxc3, pyc3,rad1, px9, py9, px11 - rad1 * 2, py11, -1,1);
                    doc.ksArcByPoint(pxc4, pyc4, rad1, px10, py10, px12 - rad1 * 2, py12, 1, 1);
                    doc.ksEndGroup();
                    doc.ksCopyObj(grpCurve, px12 - rad1 * 2, py12, px12 - rad1 * 2 - 80, py12, 1, 0);
                    doc.ksLineSeg(265, 140, px12 - rad1 * 2 - 80, py12, 1);
                    doc.ksLineSeg(265, par1.height-140, px11 - rad1 * 2 - 80, py11, 1);
                    doc.ksLineSeg(265, 140 + model1.height, px8 - 80, py8, 1);
                    doc.ksLineSeg(265, py7, px7 - 80, py7, 1);

                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxline5);
                    doc.ksDeleteObj(auxline6);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);
                    doc.ksDeleteObj(grpRect);
                    doc.ksDeleteObj(auxlineS3);
                    doc.ksDeleteObj(auxlineS4);
                    doc.ksDeleteObj(auxcurve2);
                    doc.ksDeleteObj(auxlinexcyc3);
                    doc.ksDeleteObj(auxlinexcyc4);
                    doc.ksDeleteObj(auxcircle4);
                    doc.ksDeleteObj(auxcircle5);
                    
                    //За основу взята модель 21
                }
            }
        }

        public static void Econom27()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    reference grpRect = doc.ksNewGroup(0);
                    model1.x = 265;
                    model1.y = 140;
                    model1.height = (par1.height / 2 - 180);
                    model1.width = ((par1.width - 405) - 160) / 3;
                    model1.style = 6;
                    doc.ksRectangle(model1);
                    model2.x = 265;
                    model2.y = (par1.height / 2 + 40);
                    model2.height = (par1.height / 2 - 180);
                    model2.width = ((par1.width - 405) - 160) / 3;
                    model2.style = 6;
                    doc.ksRectangle(model2);
                    doc.ksEndGroup();

                    double rad1 = par1.height / 2 - 140;
                    reference auxcircle = doc.ksCircle(par1.width - 140 - rad1, par1.height / 2, rad1, 1);//вспомогательная окружность для построения
                    reference auxline1 = doc.ksLine(0, par1.height / 2 + 40, 180);//линии 40 усечения центральной части или начальные точки дуг
                    reference auxline2 = doc.ksLine(0, par1.height / 2 - 40, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - 140 - rad1 / 2, 180);//точки соединения дуг
                    reference auxline4 = doc.ksLine(0, 140 + rad1 / 2, 180);

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height / 2 + 40, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height / 2 - 40, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, par1.height - 140 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectCirLin(par1.width - 140 - rad1, par1.height / 2, rad1, 0, 140 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference auxlinexcyc1 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, 30);//получаем центры крайних дуг(точки расположены под углом 30 градсов и на расстоянии двух радиусов)
                    reference auxlinexcyc2 = doc.ksLine(par1.width - 140 - rad1, par1.height / 2, -30);//строим 2 прямые из цетра главной окружности под углом 30 и -30 градусов и еще две из отступов 140 точки пересечения и будут центрами
                    reference auxline5 = doc.ksLine(0, par1.height - 140, 180);//линии 140-радиус конечные точки дуг
                    reference auxline6 = doc.ksLine(0, 140, 180);
                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, 30, 0, par1.height - 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - 140 - rad1, par1.height / 2, -30, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 1);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 1);
                    reference auxlineS1 = doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, 6);
                    reference auxlineS2 = doc.ksLineSeg(265 + model1.width + 80, 140, par1.width, 140, 6);
                    mat.ksIntersectLinSCir(265 + model1.width + 80, par1.height - 140, par1.width,
                        par1.height - 140, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px5 = par.x;
                    double py5 = par.y;
                    reference auxlineS3 = doc.ksLineSeg(265 + model1.width + 80, par1.height - 140, px5, py5, 6);

                    mat.ksIntersectLinSCir(265 + model1.width + 80, 140, par1.width, 140, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px6 = par.x;
                    double py6 = par.y;
                    reference auxlineS4 = doc.ksLineSeg(265 + model1.width + 80, 140, px6, py6, 6);

                    doc.ksLineSeg(265, 140, 265, 140 + model1.height, 1);
                    doc.ksLineSeg(265, 140 + model1.height + 80, 265, par1.height - 140, 1);

                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px1, py1, px3, py3, 1, 1);//построение центральных дуг
                    doc.ksArcByPoint(par1.width - 140 - rad1, par1.height / 2, rad1, px2, py2, px4, py4, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px3, py3, px5, py5, -1, 1);//построение крайних дуг
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px4, py4, px6, py6, 1, 1);

                    //строим нижню часть накладки
                    reference auxcurve2 = doc.ksArcByPoint(240 + rad1, par1.height / 2, rad1, 240 + rad1, 140,
                        240 + rad1, par1.height - 140, 1, 6);
                    mat.ksIntersectArcLin(240 + rad1, par1.height / 2, rad1, 270, 90, 1, 0, par1.height / 2 + 40, 180, arr);
                    GetPoint(arr, par);
                    double px7 = par.x;//40е от центра точки пересечения
                    double py7 = par.y;
                    mat.ksIntersectArcLin(240 + rad1, par1.height / 2, rad1, 270, 90, 1, 0, par1.height / 2 - 40, 180, arr);
                    GetPoint(arr, par);
                    double px8 = par.x;
                    double py8 = par.y;
                    doc.ksLineSeg(px7, py7, px1, py1, 1);
                    doc.ksLineSeg(px8, py8, px2, py2, 1);
                    mat.ksIntersectArcLin(240 + rad1, par1.height / 2, rad1, 270, 90, 1, 0,
                        par1.height - 140 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px9 = par.x;//точки соединения дуг
                    double py9 = par.y;
                    mat.ksIntersectArcLin(240 + rad1, par1.height / 2, rad1, 270, 90, 1, 0,
                        140 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px10 = par.x;
                    double py10 = par.y;
                    reference auxlinexcyc3 = doc.ksLine(240 + rad1, par1.height / 2, 30);
                    reference auxlinexcyc4 = doc.ksLine(240 + rad1, par1.height / 2, -30);
                    mat.ksIntersectLinLin(0, par1.height - 140, 180, 240 + rad1, par1.height / 2, 30, arr);
                    GetPoint(arr, par);
                    double pxc3 = par.x;
                    double pyc3 = par.y;
                    mat.ksIntersectLinLin(0, 140, 180, 240 + rad1, par1.height / 2, -30, arr);
                    GetPoint(arr, par);
                    double pxc4 = par.x;
                    double pyc4 = par.y;
                    reference auxcircle4 = doc.ksCircle(pxc3, pyc3, rad1, 6);
                    reference auxcircle5 = doc.ksCircle(pxc4, pyc4, rad1, 6);
                    mat.ksIntersectCirLin(pxc3, pyc3, rad1, 0, par1.height - 140, 180, arr);
                    GetPoint(arr, par);
                    double px11 = par.x;//крайние точки
                    double py11 = par.y;
                    mat.ksIntersectCirLin(pxc4, pyc4, rad1, 0, 140, 180, arr);
                    GetPoint(arr, par);
                    double px12 = par.x;
                    double py12 = par.y;
                    reference Trimmline = doc.ksLineSeg(px11 - rad1 * 2, py11, px5, py5, 1);
                    reference Trimmline2 = doc.ksLineSeg(px12 - rad1 * 2, py12, px6, py6, 1);

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(240 + rad1, par1.height / 2, rad1, px7, py7, px9, py9, 1, 1);
                    doc.ksArcByPoint(240 + rad1, par1.height / 2, rad1, px8, py8, px10, py10, -1, 1);
                    doc.ksArcByPoint(pxc3, pyc3, rad1, px9, py9, px11 - rad1 * 2, py11, -1, 1);
                    doc.ksArcByPoint(pxc4, pyc4, rad1, px10, py10, px12 - rad1 * 2, py12, 1, 1);
                    doc.ksEndGroup();
                    doc.ksCopyObj(grpCurve, px12 - rad1 * 2, py12, px12 - rad1 * 2 - 80, py12, 1, 0);
                    doc.ksLineSeg(265, 140, px12 - rad1 * 2 - 80, py12, 1);
                    doc.ksLineSeg(265, par1.height - 140, px11 - rad1 * 2 - 80, py11, 1);
                    doc.ksLineSeg(265, 140 + model1.height, px8 - 80, py8, 1);
                    doc.ksLineSeg(265, py7, px7 - 80, py7, 1);
                    doc.ksCopyObj(grpCurve, px7, py7-40, px7, py7-40, 1, 180);
                    doc.ksSymmetryObj(auxcircle5, px8, py8, px8, py8+1, "0");//центр нижней дуги (наглядно удалить doc.ksDeleteObj(auxcircle5);)
                    doc.ksTrimmCurve(Trimmline, px11 - rad1 * 2 /*+ 190*/, py11, px5, py5, px11 - rad1 * 2 + 300, py11, 1);//Bug 190 заменить на нормальную точку
                    doc.ksTrimmCurve(Trimmline2, px12 - rad1 * 2 /*+ 190*/, py12, px6, py6, px12 - rad1 * 2 + 300, py12, 1);

                    doc.ksDeleteObj(grpCurve);
                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxline5);
                    doc.ksDeleteObj(auxline6);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);
                    doc.ksDeleteObj(grpRect);
                    doc.ksDeleteObj(auxlineS3);
                    doc.ksDeleteObj(auxlineS4);
                    doc.ksDeleteObj(auxcurve2);
                    doc.ksDeleteObj(auxlinexcyc3);
                    doc.ksDeleteObj(auxlinexcyc4);
                    doc.ksDeleteObj(auxcircle4);
                    doc.ksDeleteObj(auxcircle5);

                    //За основу взята модель 26 Bug найти точки по линиям как в модели 24 
                }
            }
        }

        public static void Econom28()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(265, 140, par1.width / 5 + 265, 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 5 + 265, par1.height - 140, 1);
                    doc.ksLineSeg(par1.width / 5 + 240 + 265, 140, par1.width - 140, 140, 1);
                    doc.ksLineSeg(par1.width - 140, 140, par1.width - 140, par1.height - 140, 1);
                    doc.ksLineSeg(par1.width / 5 + 240 + 265, par1.height - 140, par1.width - 140, par1.height - 140,1);
                    doc.ksArcBy3Points(par1.width / 5 + 265, 140, par1.width / 5 + 265 + 120 - 70 - (par1.width / 50) * 3, par1.height / 2,
                        par1.width / 5 + 265, par1.height - 140, 1);
                    doc.ksArcBy3Points(par1.width / 5 + 240 + 265, 140, par1.width / 5 + 265 + 120 + 70 + (par1.width / 50) * 3,
                        par1.height / 2, par1.width / 5 + 240 + 265, par1.height - 140, 1);
                    ksEllipseParam Epar =
                        (ksEllipseParam) kompas.GetParamStruct((short) StructType2DEnum.ko_EllipseParam);      
                        Epar.xc = par1.width / 5 + 265 + 120;//координаты центра
                        Epar.yc = par1.height/2;
                        Epar.A = (par1.width / 50) * 3;//длина эллипса по Х
                        Epar.B = par1.height / 2 - 140;// длина эллипса по Y
                        Epar.style = 1;
                    reference _ell1 = doc.ksEllipse(Epar);
                    doc.ksEllipse(_ell1);
                    //double xc, yc координаты центра эллипса
                    //double a, b длина полуосей эллипса
                    //double ang угол наклона оси а эллипса к оси X
                    //style стиль линии
                }
            }
        }// ksEllipce построение эллипса tutor

        public static void Econom29()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    Point1.x = 265;
                    Point1.y = 140;
                    Point2.x = par1.width - 80 - 140;
                    Point2.y = 140;                
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x, par1.height - 140, Point2.x, par1.height - 140, 1);
                    doc.ksLineSeg(Point1.x, Point1.y, Point1.x, par1.height - 140, 1);
                    doc.ksArcByPoint(par1.width - 140 - (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80), Point2.x,
                        Point1.y, Point2.x, par1.height - 140, 1, 1);
                }
            }
        }

        public static void Econom30()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 265;
                    model1.y = 140;
                    model1.height =(par1.height -280);
                    model1.width = ((par1.width - 405) - 480) / 5;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    Point1.x = model1.width + 80 + 265;
                    Point1.y = 140;
                    Point2.x = par1.width - 80 - 140;
                    Point2.y = 140;               
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x, par1.height - 140, Point2.x, par1.height - 140, 1);
                    doc.ksLineSeg(Point1.x, Point1.y, Point1.x, par1.height - 140, 1);
                    doc.ksArcByPoint(par1.width - 140 - (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80), Point2.x,
                        Point1.y, Point2.x, par1.height - 140, 1, 1);
                }
            }
        }

        public static void Econom31()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    Point1.x = par1.width / 2.5 + 80;
                    Point1.y = 140;
                    Point2.x = par1.width - 80 - 140;
                    Point2.y = 140;
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x, par1.height - 140, Point2.x, par1.height - 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, 140, par1.width / 2.5, 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5, par1.height - 140, 1);
                    doc.ksArcByPoint(par1.width - 140 - (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80), Point2.x,
                        Point1.y, Point2.x, par1.height - 140, 1, 1);
                    //xc, yc-координаты центра дуги,
                    //rad -радиус дуги,
                    //x1, y1 -координаты начальной точки дуги,
                    //x2, y2-координаты конечной точки дуги,
                    //direction-направление отрисовки дуги:1 - против часовой стрелки,-1 - по часовой стрелке,
                    //style-стиль линии.
                    reference grpEco31 = doc.ksNewGroup(0);
                    doc.ksArcByPoint(
                        (par1.width / 2.5) - 80 + (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80), par1.width / 2.5,
                        Point1.y, par1.width / 2.5, par1.height - 140, -1, 1);
                    doc.ksEndGroup();
                    doc.ksArcByPoint(
                        (par1.width / 2.5) - 80 + (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80), par1.width / 2.5,
                        Point1.y, par1.width / 2.5, par1.height - 140, -1, 1);
                    doc.ksMoveObj(grpEco31, 80, 0);
                }
            }
        }

        public static void Econom32()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    Point1.x = par1.width / 2.5 + 80;
                    Point1.y = 140;
                    Point2.x = par1.width - 80 - 140;
                    Point2.y = 140;
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x, par1.height - 140, Point2.x, par1.height - 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, 140, par1.width / 2.5, 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5, par1.height - 140, 1);
                    doc.ksArcByPoint(par1.width - 140 - (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80), Point2.x,
                        Point1.y, Point2.x, par1.height - 140, 1, 1);
                    //xc, yc-координаты центра дуги,
                    //rad -радиус дуги,
                    //x1, y1 -координаты начальной точки дуги,
                    //x2, y2-координаты конечной точки дуги,
                    //direction-направление отрисовки дуги:1 - против часовой стрелки,-1 - по часовой стрелке,
                    //style-стиль линии.
                    reference grpEco31 = doc.ksNewGroup(0);
                    doc.ksArcByPoint(
                        (par1.width / 2.5) + 80 - (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80), par1.width / 2.5,
                        Point1.y, par1.width / 2.5, par1.height - 140, 1, 1);
                    doc.ksEndGroup();
                    doc.ksArcByPoint(
                        (par1.width / 2.5) + 80 - (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80), par1.width / 2.5,
                        Point1.y, par1.width / 2.5, par1.height - 140, 1, 1);
                    doc.ksMoveObj(grpEco31, 80, 0);
                }
            }
        }

        public static void Econom33()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                //создание фрагмента
                {
                    Zagotovka(par1);
                    Point1.x = par1.width / 2.5 + 160;
                    Point1.y = 140;
                    Point2.x = par1.width - 80 - 140;
                    Point2.y = 140;
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x, par1.height - 140, Point2.x, par1.height - 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, 140, par1.width / 2.5 - 80, 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5 - 80, par1.height - 140, 1);
                    doc.ksArcByPoint(par1.width - 140 - (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80), Point2.x,
                        Point1.y, Point2.x, par1.height - 140, 1, 1);
                    //xc, yc-координаты центра дуги,
                    //rad -радиус дуги,
                    //x1, y1 -координаты начальной точки дуги,
                    //x2, y2-координаты конечной точки дуги,
                    //direction-направление отрисовки дуги:1 - против часовой стрелки,-1 - по часовой стрелке,
                    //style-стиль линии.
                    reference grpEco31 = doc.ksNewGroup(0);
                    doc.ksArcByPoint(
                        (par1.width / 2.5 - 80) - 80 + (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80),
                        par1.width / 2.5 - 80, Point1.y, par1.width / 2.5 - 80, par1.height - 140, -1, 1);
                    doc.ksEndGroup();
                    doc.ksArcByPoint(
                        (par1.width / 2.5 - 80) + 80 - (40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80)),
                        par1.height / 2, 40 + ((par1.height - 280) * (par1.height - 280)) / (8 * 80),
                        par1.width / 2.5 - 80, Point1.y, par1.width / 2.5 - 80, par1.height - 140, 1, 1);
                    doc.ksMoveObj(grpEco31, 240, 0);
                }
            }
        } //Arcbypoint tutor

        public static void Econom34()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    //верхняя часть
                    double rad1 = par1.height / 10;
                    doc.ksArcByPoint(par1.width - (par1.width-100)/10, par1.height - 140, rad1, par1.width - (par1.width-100)/10,
                        par1.height - 140 - rad1, par1.width - (par1.width-100)/10 - rad1, par1.height - 140, -1, 1);
                    doc.ksArcByPoint(par1.width - (par1.width-100)/10, 140, rad1, par1.width - (par1.width-100)/10, 140 + rad1, par1.width - (par1.width-100)/10 - rad1,
                        140, 1, 1);
                    doc.ksArcBy3Points(par1.width - (par1.width-100)/10, 140 + rad1, par1.width - 140, par1.height / 2,
                        par1.width - (par1.width-100)/10, par1.height - 140 - rad1, 1);
                    doc.ksArcByPoint(par1.width / 2.5 + 80, 140, rad1, par1.width / 2.5 + 80 + rad1, 140,
                        par1.width / 2.5 + 80, 140 + rad1, 1, 1);
                    doc.ksArcByPoint(par1.width / 2.5 + 80, par1.height - 140, rad1, par1.width / 2.5 + 80 + rad1,
                        par1.height - 140, par1.width / 2.5 + 80, par1.height - 140 - rad1, -1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5 + 80, 140 + rad1,
                        par1.width / 2.5 + (80 - ((par1.width - 100) / 10 - 140)), par1.height / 2,
                        par1.width / 2.5 + 80, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1, 140, par1.width - (par1.width-100)/10 - rad1, 140, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1, par1.height - 140, par1.width - (par1.width-100)/10 - rad1,
                        par1.height - 140, 1);

                    //нижняя часть

                    doc.ksArcByPoint(par1.width / 2.5, 140, rad1, par1.width / 2.5 - rad1, 140, par1.width / 2.5,
                        140 + rad1, -1, 1);
                    doc.ksArcByPoint(par1.width / 2.5, par1.height - 140, rad1, par1.width / 2.5 - rad1,
                        par1.height - 140, par1.width / 2.5, par1.height - 140 - rad1, 1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5, 140 + rad1, par1.width / 2.5 - ((par1.width - 100) / 10 - 140),
                        par1.height / 2, par1.width / 2.5, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(265, 140, par1.width / 2.5 - rad1, 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5 - rad1, par1.height - 140, 1);
                }
            }
        }

        public static void Econom35()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    //верхняя часть верхней части накладки
                    double rad1 = par1.height / 10;
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, par1.height - 140, rad1, par1.width - (par1.width - 100) / 10,
                        par1.height - 140 - rad1, par1.width - (par1.width - 100) / 10 - rad1, par1.height - 140, -1, 1);
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, 140, rad1, par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - (par1.width - 100) / 10 - rad1,
                        140, 1, 1);
                    doc.ksArcBy3Points(par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - 140, par1.height / 2,
                        par1.width - (par1.width - 100) / 10, par1.height - 140 - rad1, 1);
                    // нижняя часть верхней части накладки
                    doc.ksArcByPoint(par1.width / 2.5 + 80+ ((par1.width - 100) / 10 - 90)- (2000-par1.width)/10, 140, rad1, par1.width / 2.5 + 80 + rad1+ ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, 140,
                        par1.width / 2.5 + 80+ ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, 140 + rad1, 1, 1);
                    doc.ksArcByPoint(par1.width / 2.5 + 80+ ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, par1.height - 140, rad1, par1.width / 2.5 + 80 + rad1+ ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10,
                        par1.height - 140, par1.width / 2.5+ ((par1.width - 100) / 10 - 90) + 80 - (2000 - par1.width) / 10, par1.height - 140 - rad1, -1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5 + 80+ ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, 140 + rad1,
                        par1.width / 2.5 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10 + (80 - ((par1.width - 100) / 10 - 140)), par1.height / 2,
                        par1.width / 2.5 + 80+ ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, 140, par1.width - (par1.width - 100) / 10 - rad1, 140, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, par1.height - 140, par1.width - (par1.width - 100) / 10 - rad1,
                        par1.height - 140, 1);

                    //полная нижняя часть накладки
                    doc.ksArcByPoint(par1.width / 2.5, 140, rad1, par1.width / 2.5 - rad1, 140, par1.width / 2.5,
                        140 + rad1, -1, 1);
                    doc.ksArcByPoint(par1.width / 2.5, par1.height - 140, rad1, par1.width / 2.5 - rad1,
                        par1.height - 140, par1.width / 2.5, par1.height - 140 - rad1, 1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5, 140 + rad1, par1.width / 2.5 + ((par1.width - 100) / 10 - 140),
                        par1.height / 2, par1.width / 2.5, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(265, 140, par1.width / 2.5 - rad1, 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5 - rad1, par1.height - 140, 1);
                }
            }
        }

        public static void Econom36()
        {
            
        }

        public static void Econom37()
        {
        }

        public static void Econom38()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 10;
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, par1.height - 140, rad1, par1.width - (par1.width - 100) / 10,
                        par1.height - 140 - rad1, par1.width - (par1.width - 100) / 10 - rad1, par1.height - 140, -1, 1);
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, 140, rad1, par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - (par1.width - 100) / 10 - rad1,
                        140, 1, 1);
                    doc.ksArcBy3Points(par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - 140, par1.height / 2,
                        par1.width - (par1.width - 100) / 10, par1.height - 140 - rad1, 1);
                    doc.ksArcByPoint(par1.width / 2.5 + 80, 140, rad1, par1.width / 2.5 + 80 + rad1, 140,
                        par1.width / 2.5 + 80, 140 + rad1, 1, 1);
                    doc.ksArcByPoint(par1.width / 2.5 + 80, par1.height - 140, rad1, par1.width / 2.5 + 80 + rad1,
                        par1.height - 140, par1.width / 2.5 + 80, par1.height - 140 - rad1, -1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5 + 80, 140 + rad1,
                        par1.width / 2.5 + (80 - ((par1.width - 100) / 10 - 140)), par1.height / 2,
                        par1.width / 2.5 + 80, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1, 140, par1.width - (par1.width - 100) / 10 - rad1, 140, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1, par1.height - 140, par1.width - (par1.width - 100) / 10 - rad1,
                        par1.height - 140, 1);

                    doc.ksArcByPoint(par1.width / 2.5, 140, rad1, par1.width / 2.5 - rad1, 140, par1.width / 2.5,
                        140 + rad1, -1, 1);
                    doc.ksArcByPoint(par1.width / 2.5, par1.height - 140, rad1, par1.width / 2.5 - rad1,
                        par1.height - 140, par1.width / 2.5, par1.height - 140 - rad1, 1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5, 140 + rad1, par1.width / 2.5 - ((par1.width - 100) / 10 - 140),
                        par1.height / 2, par1.width / 2.5, par1.height - 140 - rad1, 1);
                    doc.ksArcByPoint(265, 140, rad1, 265 + rad1, 140, 265, 140 + rad1, 1, 1);
                    doc.ksArcByPoint(265, par1.height - 140, rad1, 265 + rad1, par1.height - 140, 265,
                        par1.height - 140 - rad1, -1, 1);
                    doc.ksLineSeg(265, 140 + rad1, 265, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(265 + rad1, 140, par1.width / 2.5 - rad1, 140, 1);
                    doc.ksLineSeg(265 + rad1, par1.height - 140, par1.width / 2.5 - rad1, par1.height - 140, 1);
                }
            }
        }

        public static void Econom39()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    //верхняя часть верхней части накладки
                    double rad1 = par1.height / 10;
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, par1.height - 140, rad1, par1.width - (par1.width - 100) / 10,
                        par1.height - 140 - rad1, par1.width - (par1.width - 100) / 10 - rad1, par1.height - 140, -1, 1);
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, 140, rad1, par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - (par1.width - 100) / 10 - rad1,
                        140, 1, 1);
                    doc.ksArcBy3Points(par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - 140, par1.height / 2,
                        par1.width - (par1.width - 100) / 10, par1.height - 140 - rad1, 1);
                    // нижняя часть верхней части накладки
                    doc.ksArcByPoint(par1.width / 2.5 + 80 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, 140, rad1, par1.width / 2.5 + 80 + rad1 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, 140,
                        par1.width / 2.5 + 80 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, 140 + rad1, 1, 1);
                    doc.ksArcByPoint(par1.width / 2.5 + 80 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, par1.height - 140, rad1, par1.width / 2.5 + 80 + rad1 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10,
                        par1.height - 140, par1.width / 2.5 + ((par1.width - 100) / 10 - 90) + 80 - (2000 - par1.width) / 10, par1.height - 140 - rad1, -1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5 + 80 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, 140 + rad1,
                        par1.width / 2.5 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10 + (80 - ((par1.width - 100) / 10 - 140)), par1.height / 2,
                        par1.width / 2.5 + 80 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, 140, par1.width - (par1.width - 100) / 10 - rad1, 140, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1 + ((par1.width - 100) / 10 - 90) - (2000 - par1.width) / 10, par1.height - 140, par1.width - (par1.width - 100) / 10 - rad1,
                        par1.height - 140, 1);

                    //полная нижняя часть накладки
                    doc.ksArcByPoint(par1.width / 2.5, 140, rad1, par1.width / 2.5 - rad1, 140, par1.width / 2.5,
                        140 + rad1, -1, 1);
                    doc.ksArcByPoint(par1.width / 2.5, par1.height - 140, rad1, par1.width / 2.5 - rad1,
                        par1.height - 140, par1.width / 2.5, par1.height - 140 - rad1, 1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5, 140 + rad1, par1.width / 2.5 + ((par1.width - 100) / 10 - 140),
                        par1.height / 2, par1.width / 2.5, par1.height - 140 - rad1, 1);
                    doc.ksArcByPoint(265, 140, rad1, 265 + rad1, 140, 265, 140 + rad1, 1, 1);
                    doc.ksArcByPoint(265, par1.height - 140, rad1, 265 + rad1, par1.height - 140, 265,
                        par1.height - 140 - rad1, -1, 1);
                    doc.ksLineSeg(265, 140 + rad1, 265, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(265 + rad1, 140, par1.width / 2.5 - rad1, 140, 1);
                    doc.ksLineSeg(265 + rad1, par1.height - 140, par1.width / 2.5 - rad1, par1.height - 140, 1);


                }
            }
        }

        public static void Econom40()
        {
        }

        public static void Econom41()
        {
        }

        public static void Econom42()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 10;
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, par1.height - 140, rad1, par1.width - (par1.width - 100) / 10,
                        par1.height - 140 - rad1, par1.width - (par1.width - 100) / 10 - rad1, par1.height - 140, -1, 1);
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, 140, rad1, par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - (par1.width - 100) / 10 - rad1,
                        140, 1, 1);
                    doc.ksArcBy3Points(par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - 140, par1.height / 2,
                        par1.width - (par1.width - 100) / 10, par1.height - 140 - rad1, 1);
                    doc.ksArcByPoint(265, 140, rad1, 265 + rad1, 140, 265, 140 + rad1, 1, 1);
                    doc.ksArcByPoint(265, par1.height - 140, rad1, 265 + rad1, par1.height - 140, 265,
                        par1.height - 140 - rad1, -1, 1);
                    doc.ksLineSeg(265, 140 + rad1, 265, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(265 + rad1, 140, par1.width - (par1.width - 100) / 10 - rad1, 140, 1);
                    doc.ksLineSeg(265 + rad1, par1.height - 140, par1.width - (par1.width - 100) / 10 - rad1,
                        par1.height - 140, 1);
                }
            }
        }

        public static void Econom43()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(par1.width - 400, par1.height / 2 - 200, par1.width - 400, par1.height / 2 - 30, 1);
                    doc.ksLineSeg(par1.width - 600, par1.height / 2 - 30, par1.width - 400, par1.height / 2 - 30, 1);
                    doc.ksLineSeg(par1.width - 340, par1.height / 2 - 200, par1.width - 340, par1.height / 2 - 30, 1);
                    doc.ksLineSeg(par1.width - 340, par1.height / 2 - 30, par1.width - 140, par1.height / 2 - 30, 1);
                    doc.ksLineSeg(par1.width - 340, par1.height / 2 + 30, par1.width - 140, par1.height / 2 + 30, 1);
                    doc.ksLineSeg(par1.width - 340, par1.height / 2 + 30, par1.width - 340, par1.height / 2 + 200, 1);
                    doc.ksLineSeg(par1.width - 400, par1.height / 2 + 30, par1.width - 400, par1.height / 2 + 200, 1);
                    doc.ksLineSeg(par1.width - 600, par1.height / 2 + 30, par1.width - 400, par1.height / 2 + 30, 1);
                    doc.ksArcBy3Points(par1.width - 600, par1.height / 2 - 30, par1.width - 560, par1.height / 2 - 115, par1.width - 400,
                        par1.height / 2 - 200, 1);
                    doc.ksArcBy3Points(par1.width - 340, par1.height / 2 - 200, par1.width - 180, par1.height / 2 - 115, par1.width - 140,
                        par1.height / 2 - 30, 1);
                    doc.ksArcBy3Points(par1.width - 600, par1.height / 2 + 30, par1.width - 560, par1.height / 2 + 115,
                        par1.width - 400, par1.height / 2 + 200, 1);
                    doc.ksArcBy3Points(par1.width - 340, par1.height / 2 + 200, par1.width - 180, par1.height / 2 + 115,
                        par1.width - 140, par1.height / 2 + 30, 1);
                    doc.ksLineSeg(265, par1.height / 2 - 200, 265, par1.height / 2 - 30, 1);
                    doc.ksLineSeg(265, par1.height / 2 + 30, 265, par1.height / 2 + 200, 1);
                    doc.ksLineSeg(265, par1.height / 2 - 30, par1.width - 680, par1.height / 2 - 30, 1);
                    doc.ksLineSeg(265, par1.height / 2 - 200, par1.width - 589, par1.height / 2 - 200, 1);
                    doc.ksLineSeg(265, par1.height / 2 + 30, par1.width - 680, par1.height / 2 + 30, 1);
                    doc.ksLineSeg(265, par1.height / 2 + 200, par1.width - 589, par1.height / 2 + 200, 1);
                    doc.ksArcBy3Points(par1.width - 680, par1.height / 2 - 30, par1.width - 652, par1.height / 2 - 115, par1.width - 589,
                        par1.height / 2 - 200, 1);
                    doc.ksArcBy3Points(par1.width - 680, par1.height / 2 + 30, par1.width - 652, par1.height / 2 + 115,
                        par1.width - 589, par1.height / 2 + 200, 1);
                }
            }
        }//Bug статичная(оставить)?

        public static void Econom44()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                Zagotovka(par1);
                model1.x = 265;
                model1.y = 140;
                model1.height = (par1.height / 2 -140-40);
                model1.width = (par1.width -265 - 140 - 240 - ((par1.height / 2) - 140))/3;//par1.width * (16.5925 / 100)
                model1.style = 1;
                doc.ksRectangle(model1);
                model2.x = 265;
                model2.y = par1.height/2+40;
                model2.height = (par1.height / 2 - 140 - 40);
                model2.width = (par1.width - 265 - 140 - 240 - ((par1.height / 2) - 140)) / 3;
                model2.style = 1;
                doc.ksRectangle(model2);
                model3.x = 265+80 +model1.width;
                model3.y = 140;
                model3.height = (par1.height / 2 - 140 - 40);
                model3.width = (par1.width - 265 - 140 - 240 - ((par1.height / 2) - 140)) / 3;
                model3.style = 1;
                doc.ksRectangle(model3);
                model4.x = 265 + 80 + model1.width;
                model4.y = par1.height / 2 + 40;
                model4.height = (par1.height / 2 - 140 - 40);;
                model4.width = (par1.width - 265 - 140 - 240 - ((par1.height / 2) - 140)) / 3;
                model4.style = 1;
                doc.ksRectangle(model4);
                model5.x = 265 + 80*2 + model1.width*2;
                model5.y = 140;
                model5.height = (par1.height / 2 - 140 - 40);
                model5.width = (par1.width - 265 - 140 - 240 - ((par1.height / 2) - 140)) / 3;
                model5.style = 1;
                doc.ksRectangle(model5);
                model6.x = 265 + 80 * 2 + model1.width * 2;
                model6.y = par1.height / 2 + 40;
                model6.height = (par1.height / 2 - 140 - 40);
                model6.width = (par1.width - 265 - 140 - 240 - ((par1.height / 2) - 140)) / 3;
                model6.style = 1;
                doc.ksRectangle(model6);
                doc.ksLineSeg(265 + 80 * 3 + model1.width * 3, 140, 265 + 80 * 3 + model1.width * 3, par1.height / 2 - 40, 1);
                doc.ksLineSeg(265 + 80 * 3 + model1.width * 3, par1.height / 2 - 40,par1.width- par1.width/7.528136,par1.height/4.42028,1);      
                doc.ksLineSeg(265 + 80 * 3 + model1.width * 3+36.57, par1.height/2-20,par1.width-140,par1.height/2-20,1);
                doc.ksLineSeg(265 + 80 * 3 + model1.width * 3 + 36.57, par1.height / 2 - 20,par1.width- par1.width/ 8.448086, par1.height/3.939173, 1);
                doc.ksLineSeg(265 + 80 * 3 + model1.width * 3 + 36.57, par1.height / 2 + 20,par1.width-140,par1.height/2+20,1);
                doc.ksLineSeg(265 + 80 * 3 + model1.width * 3 + 36.57, par1.height / 2 + 20, par1.width - par1.width / 8.448086, par1.height- par1.height / 3.939173, 1);
                doc.ksLineSeg(265 + 80 * 3 + model1.width * 3, par1.height / 2 + 40, 265 + 80 * 3 + model1.width * 3, par1.height - 140, 1);
                doc.ksLineSeg(265 + 80 * 3 + model1.width * 3, par1.height / 2 + 40, par1.width - par1.width / 7.528136,par1.height- par1.height / 4.42028, 1);
                doc.ksArcByPoint(265 + 80 * 3 + model1.width * 3, par1.height / 2, par1.height/2-140, 265 + 80 * 3 + model1.width * 3,
                    par1.height / 2 - 40,par1.width- par1.width / 7.528136, par1.height / 4.42028, 1,1);
                doc.ksArcByPoint(265 + 80 * 3 + model1.width * 3, par1.height / 2, par1.height / 2 - 140, par1.width - 140,
                    par1.height / 2 - 20,par1.width- par1.width / 8.448086, par1.height / 3.939173, -1, 1);
                doc.ksArcByPoint(265 + 80 * 3 + model1.width * 3, par1.height / 2, par1.height / 2 - 140, par1.width - 140,
                    par1.height / 2 + 20, par1.width - par1.width / 8.448086, par1.height - par1.height / 3.939173, 1, 1);
                doc.ksArcByPoint(265 + 80 * 3 + model1.width * 3, par1.height / 2, par1.height / 2 - 140, 265 + 80 * 3 + model1.width * 3,
                    par1.height - 140, par1.width - par1.width / 7.528136, par1.height - par1.height / 4.42028, -1, 1);
            }
        }//Bug переделать шапку накладки(именно линии)

        public static void Econom45()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 140;
                    model1.y = 140;
                    model1.height = par1.height - 280;
                    model1.width = par1.width - 280;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    Point1.x = model1.width / 5 + 140;
                    Point1.y = 140;
                    Point2.x = model1.width / 5 + 140;
                    Point2.y = par1.height - 140;               
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg((model1.width / 5) * 2 + 140, Point1.y, (model1.width / 5) * 2 + 140, Point2.y, 1);
                    doc.ksLineSeg((model1.width / 5) * 3 + 140, Point1.y, (model1.width / 5) * 3 + 140, Point2.y, 1);
                    doc.ksLineSeg((model1.width / 5) * 4 + 140, Point1.y, (model1.width / 5) * 4 + 140, Point2.y, 1);
                }
            }
        }

        public static void Econom46()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 10;
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, par1.height - 140, rad1, par1.width - (par1.width - 100) / 10,
                        par1.height - 140 - rad1, par1.width - (par1.width - 100) / 10 - rad1, par1.height - 140, -1, 1);
                    doc.ksArcByPoint(par1.width - (par1.width - 100) / 10, 140, rad1, par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - (par1.width - 100) / 10 - rad1,
                        140, 1, 1);
                    doc.ksArcBy3Points(par1.width - (par1.width - 100) / 10, 140 + rad1, par1.width - 140, par1.height / 2,
                        par1.width - (par1.width - 100) / 10, par1.height - 140 - rad1, 1);
                    doc.ksArcByPoint(par1.width / 2.5 + 80, 140, rad1, par1.width / 2.5 + 80 + rad1, 140,
                        par1.width / 2.5 + 80, 140 + rad1, 1, 1);
                    doc.ksArcByPoint(par1.width / 2.5 + 80, par1.height - 140, rad1, par1.width / 2.5 + 80 + rad1,
                        par1.height - 140, par1.width / 2.5 + 80, par1.height - 140 - rad1, -1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5 + 80, 140 + rad1,
                        par1.width / 2.5 + (80 - ((par1.width - 100) / 10 - 140)), par1.height / 2,
                        par1.width / 2.5 + 80, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1, 140, par1.width - (par1.width - 100) / 10 - rad1, 140, 1);
                    doc.ksLineSeg(par1.width / 2.5 + 80 + rad1, par1.height - 140, par1.width - (par1.width - 100) / 10 - rad1,
                        par1.height - 140, 1);
                    ksEllipseParam Epar =
                        (ksEllipseParam)kompas.GetParamStruct((short)StructType2DEnum.ko_EllipseParam);
                    Epar.xc = par1.width / 2.5 +
                              ((par1.width - par1.width / 2.5 - rad1 * 2 - 80 - (par1.width - 100) / 10) / 2)+80+rad1; //координаты центра
                    Epar.yc = par1.height / 2;
                    Epar.A = (par1.width-par1.width/2.5-140- (80 - ((par1.width - 100) / 10 - 140)))/2-100;//длина эллипса по Х
                    Epar.B = par1.height / 2 - 140 - 100;// длина эллипса по Y
                    Epar.style = 1;
                    reference _ell1 = doc.ksEllipse(Epar);
                    doc.ksEllipse(_ell1);
                    //double xc, yc координаты центра эллипса
                    //double a, b длина полуосей эллипса
                    //double ang угол наклона оси а эллипса к оси X
                    //style стиль линии

                    doc.ksArcByPoint(par1.width / 2.5, 140, rad1, par1.width / 2.5 - rad1, 140, par1.width / 2.5,
                        140 + rad1, -1, 1);
                    doc.ksArcByPoint(par1.width / 2.5, par1.height - 140, rad1, par1.width / 2.5 - rad1,
                        par1.height - 140, par1.width / 2.5, par1.height - 140 - rad1, 1, 1);
                    doc.ksArcBy3Points(par1.width / 2.5, 140 + rad1, par1.width / 2.5 - ((par1.width - 100) / 10 - 140),
                        par1.height / 2, par1.width / 2.5, par1.height - 140 - rad1, 1);
                    doc.ksLineSeg(265, 140, par1.width / 2.5 - rad1, 140, 1);
                    doc.ksLineSeg(265, 140, 265, par1.height - 140, 1);
                    doc.ksLineSeg(265, par1.height - 140, par1.width / 2.5 - rad1, par1.height - 140, 1);

                    doc.ksLineSeg(265 + 100, 140 + 100, par1.width / 2.5 - rad1-(100-rad1), 140 + 100, 1);
                    doc.ksLineSeg(265 + 100, par1.height - 140 - 100, par1.width / 2.5 - rad1 - (100 - rad1), par1.height - 140 - 100, 1);
                    doc.ksLineSeg(265 + 100, 140 + 100, 265 + 100, par1.height - 140 - 100, 1);
                    doc.ksArcBy3Points(par1.width / 2.5 - rad1- (100 - rad1), 140 + 100,
                        par1.width / 2.5 - ((par1.width - 100) / 10 - 140) - rad1 - (100 - rad1), par1.height / 2,
                        par1.width / 2.5 - rad1 - (100 - rad1), par1.height - 140 - 100, 1);

                }
            }
        }

        public static void Econom47()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 140;
                    model1.y = 140;
                    model1.height = par1.height - 280;
                    model1.width = par1.width - 280;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    Point1.x = 140;
                    Point1.y = model1.height + 140;
                    Point2.x = model1.height + 140;
                    Point2.y = 140;               
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(140, (model1.height / 3) * 2 + 140, (model1.height / 3) * 2 + 140, 140, 1);
                    doc.ksLineSeg(140, (model1.height / 3) + 140, (model1.height / 3) + 140, 140, 1);
                }
            }
        }

        public static void Econom48()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(0, par1.height / 2 - 80, 500, par1.height / 2 - 80, 1);
                    doc.ksLineSeg(0, par1.height / 2 , 466.86, par1.height / 2 , 1);
                    doc.ksLineSeg(0, par1.height / 2 + 80, 433.73, par1.height / 2 + 80, 1);
                    doc.ksLineSeg(500, par1.height / 2 - 80, 683.79, par1.height / 2+103.79, 1);
                    doc.ksLineSeg(466.86, par1.height / 2 , 603.79, par1.height / 2 +136.92, 1);
                    doc.ksLineSeg(433.73, par1.height / 2 + 80, 523.79, par1.height / 2+170.06, 1);
                    doc.ksLineSeg(683.79, par1.height / 2 + 103.79, 683.79, par1.height, 1);
                    doc.ksLineSeg(603.79, par1.height / 2 + 136.92, 603.79, par1.height, 1);
                    doc.ksLineSeg(523.79, par1.height / 2 + 170.06, 523.79, par1.height, 1);
                    doc.ksLineSeg(556.57, 0, 556.57, par1.height/2 - 136.57, 1);
                    doc.ksLineSeg(636.57, 0, 636.57, par1.height/2 - 169.71, 1);
                    doc.ksLineSeg(716.57, 0, 716.57, par1.height/2 - 202.84, 1);
                    doc.ksLineSeg(556.57, par1.height / 2 - 136.57, 773.14, par1.height / 2 + 80, 1);
                    doc.ksLineSeg(636.57, par1.height / 2 - 169.71, 806.27, par1.height / 2, 1);
                    doc.ksLineSeg(716.57, par1.height / 2 - 202.84, 839.41, par1.height / 2-80, 1);
                    doc.ksLineSeg(773.14, par1.height / 2 + 80, par1.width, par1.height / 2 + 80, 1);
                    doc.ksLineSeg(806.27, par1.height / 2, par1.width, par1.height / 2, 1);
                    doc.ksLineSeg(839.41, par1.height / 2 - 80, par1.width, par1.height / 2 - 80, 1);
                }
            }
        }

        public static void Econom49()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    reference grpEco49 = doc.ksNewGroup(0);
                    doc.ksLineSeg(140, 140+60, par1.width / 2 - 200, 140+60, 1);
                    doc.ksLineSeg(par1.width / 2 - 200, 140+60, par1.width / 2, 140 + 115.47, 1);
                    doc.ksLineSeg(140*2,140+60*2,par1.width/2-216.08, 140 + 60 * 2,1);
                    doc.ksLineSeg(par1.width / 2 - 216.08, 140 + 60 * 2, par1.width / 2, 140 + 115.47+69.28,1);
                    doc.ksLineSeg(140*3,140+60*3, par1.width / 2 - 232.15,140+60*3,1);
                    doc.ksLineSeg(par1.width / 2 - 232.15, 140 + 60 * 3,par1.width/2, 140 + 115.47 + 69.28*2,1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpEco49, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 + 1,
                        "1");
                    doc.ksLineSeg(0,140,par1.width,140,1);
                    doc.ksLineSeg(0,par1.height-140,par1.width,par1.height-140,1);
                }
            }
        }

        public static void Econom50() //bug сделать эллипс вместо окружностей
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    //создание заготовки
                    Point1.x = 0; //
                    Point1.y = par1.height / 2 + 40; //Point1 точка начала отрезка
                    Point2.x = par1.width / 2 - 240; //
                    Point2.y = par1.height / 2 + 40; //Point2 точка конца отрезка                                   
                    doc.ksCircle(par1.width / 2, par1.height / 2, 80, 1); //координаты центра(xc,yc) ,радиус, стиль
                    doc.ksCircle(par1.width / 2, par1.height / 2, 160, 1);
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x + 3.36, Point2.y, 1);
                    doc.ksLineSeg(Point2.x + 480 - 3.36, Point1.y, par1.width, Point2.y, 1);
                    doc.ksLineSeg(Point1.x, Point1.y - 80, Point2.x - 80 + 2.51, Point2.y - 80,
                        1); //просто прямая по 2м точкам
                    doc.ksLineSeg(Point2.x + 480 + 80 - 2.51, Point1.y - 80, par1.width, Point2.y - 80, 1);
                    doc.ksArcByPoint((par1.width / 2), (par1.height / 2), 240, Point2.x + 3.36, Point2.y,
                        (Point2.x + 480 - 3.36), Point1.y, 1, 1);
                    doc.ksArcByPoint((par1.width / 2), (par1.height / 2), 320, Point2.x - 80 + 2.51, Point2.y - 80,
                        (Point2.x + 480 + 80 - 2.51), Point1.y - 80, 1, 1);
                }
            }
        }

        public static void Econom51()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    Point1.x = 0;
                    Point1.y = par1.height - 140; //Point1 точка начала отрезка
                    Point2.x = par1.width;
                    Point2.y = par1.height - 140; //Point2 точка конца отрезка                
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x, Point1.y - 80, Point2.x, Point2.y - 80, 1);
                    doc.ksLineSeg(Point1.x, 140, Point2.x, 140, 1);
                    doc.ksLineSeg(Point1.x, 140 + 80, Point2.x, 140 + 80, 1);
                    doc.ksLineSeg(Point1.x, 140 + (80 / 3) * 2, (par1.width / 3) * 2 - 140, 140 + (80 / 3) * 2, 1);
                    doc.ksLineSeg((par1.width / 3) * 2, 140 + (80 / 3) * 2, par1.width, 140 + (80 / 3) * 2, 1);
                    doc.ksLineSeg(Point1.x, 140 + (80 / 3), (par1.width / 3) * 2 - 140, 140 + (80 / 3), 1);
                    doc.ksLineSeg((par1.width / 3) * 2, 140 + (80 / 3), par1.width, 140 + (80 / 3), 1);
                }
            }
        }

        public static void Econom52()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    //создание заготовки
                    reference grpEco52 = doc.ksNewGroup(0);
                    Point1.x = 0; //
                    Point1.y = par1.height - 140; //Point1 точка начала отрезка
                    Point2.x = par1.width; //
                    Point2.y = par1.height - 140; //Point2 точка конца отрезка                
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x, Point1.y - 80, Point2.x, Point2.y - 80, 1);
                    doc.ksLineSeg(Point1.x, 140, Point2.x, 140, 1);
                    doc.ksLineSeg(Point1.x, 140 + 80, Point2.x, 140 + 80, 1);
                    doc.ksLineSeg(Point1.x, 140 + (80 / 3) * 2, (par1.width / 3) * 2 - 140, 140 + (80 / 3) * 2, 1);
                    doc.ksLineSeg((par1.width / 3) * 2, 140 + (80 / 3) * 2, par1.width, 140 + (80 / 3) * 2, 1);
                    doc.ksLineSeg(Point1.x, 140 + (80 / 3), (par1.width / 3) * 2 - 140, 140 + (80 / 3), 1);
                    doc.ksLineSeg((par1.width / 3) * 2, 140 + (80 / 3), par1.width, 140 + (80 / 3), 1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpEco52, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2,
                        "0"); // Симметрия объекта grpEco52 (предварительно сгруппировать!!!)              
                    // ref -указатель на объект,
                    // x1, y1-координаты первой точки на оси,
                    //x2, y2 -координаты второй точки на оси,
                    // copy-режим копирования:
                    // 0 - исходные объекты удаляются,
                    //1 - исходные объекты оставляются.
                }
            }
        } //Пример симметрии объекта

        public static void Econom53()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    Point1.x = 140; 
                    Point1.y = 0; //Point1 точка начала отрезка
                    Point2.x = 140;
                    Point2.y = par1.height; //Point2 точка конца отрезка                
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x + 140, Point1.y, Point2.x + 140, Point2.y, 1);
                    doc.ksLineSeg(par1.width - 140, Point1.y, par1.width - 140, Point2.y, 1);
                    doc.ksLineSeg(par1.width - 280, Point1.y, par1.width - 280, Point2.y, 1);
                }
            }
        }

        public static void Econom54()
        {
        }

        public static void Econom55()
        {
        }

        public static void Econom56()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 200;
                    model1.y = 200;
                    model1.height = (par1.height - 400);
                    model1.width = (par1.width - 400 - 80 * 4) / 5;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    model2.x = (model1.width + 80 + 200);
                    model2.y = 200;
                    model2.height = (par1.height - 400);
                    model2.width = (par1.width - 400 - 80 * 4) / 5;
                    model2.style = 1;
                    doc.ksRectangle(model2);
                    model3.x = (model1.width*2 + 80*2 + 200);
                    model3.y = 200;
                    model3.height = (par1.height - 400);
                    model3.width = (par1.width - 400 - 80 * 4) / 5;
                    model3.style = 1;
                    doc.ksRectangle(model3);
                    model4.x = (model1.width*3 + 80*3 + 200);
                    model4.y = 200;
                    model4.height = (par1.height - 400);
                    model4.width = (par1.width - 400 - 80 * 4) / 5;
                    model4.style = 1;
                    doc.ksRectangle(model4);
                    model5.x = (model1.width*4 + 80*4 + 200);
                    model5.y = 200;
                    model5.height = (par1.height - 400);
                    model5.width = (par1.width - 400 - 80 * 4) / 5;
                    model5.style = 1;
                    doc.ksRectangle(model5);
                    doc.ksArcBy3Points(160,par1.height/2,200+model1.width/2,par1.height/2-40,200+model1.width+40,par1.height/2,1);
                    doc.ksArcBy3Points(200 + model1.width + 40, par1.height / 2, 200 + model1.width*1.5 + 80,par1.height/2+40, 200 + model1.width * 2 + 80+40,par1.height/2,1);
                    doc.ksArcBy3Points(200 + model1.width * 2 + 80 + 40, par1.height / 2, 200 + model1.width * 2.5 + 80*2, par1.height / 2 - 40, 200 + model1.width * 3 + 80 * 2+40, par1.height / 2,1);
                    doc.ksArcBy3Points(200 + model1.width * 3 + 80 * 2 + 40, par1.height / 2, 200 + model1.width * 3.5 + 80 * 3, par1.height / 2 + 40, 200 + model1.width * 4 + 80 * 3+40, par1.height / 2, 1);
                    doc.ksArcBy3Points(200 + model1.width * 4 + 80 * 3 + 40, par1.height / 2, 200 + model1.width * 4.5 + 80 * 4, par1.height / 2 - 40, 200 + model1.width * 5 + 80 * 4+40, par1.height / 2, 1);
                    doc.ksCircle(model1.x+50,model1.y+60,20,1);
                    doc.ksCircle(model1.x+model1.width+80+50, par1.height-model1.y-60,20,1);
                    doc.ksCircle(model1.x + model1.width*2 + 80*2 + 50, model1.y + 60, 20, 1);
                    doc.ksCircle(model1.x + model1.width*3 + 80*3 + 50, par1.height - model1.y - 60, 20, 1);
                    doc.ksCircle(model1.x + model1.width * 4 + 80 * 4 + 50, model1.y + 60, 20, 1);

                }
            }
        }

        public static void Econom57()
        {
        }

        public static void Econom58()
        {
        }

        public static void Econom59()
        {
            doc = (ksDocument2D) kompas.Document2D();
            ksDocumentParam docPar = (ksDocumentParam) kompas.GetParamStruct((short) StructType2DEnum.ko_DocumentParam);
            ksDocumentParam docPar1 =
                (ksDocumentParam) kompas.GetParamStruct((short) StructType2DEnum.ko_DocumentParam);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                ksRectangleParam par1 =
                    (ksRectangleParam) kompas.GetParamStruct((short) StructType2DEnum.ko_RectangleParam);
                {
                    Zagotovka(par1);//создание заготовки
                    reference grpEco59 = doc.ksNewGroup(0);
                    doc.ksArcBy3Points(0, 180, par1.width / 4, 140, par1.width / 2, 180, 1);
                    doc.ksArcBy3Points(par1.width / 2, 180, (par1.width / 4) * 3, 140 + 80, par1.width, 180, 1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpEco59, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2, "1");
                }
            }
        }

        public static void Econom60()
        {
        }

        public static void Econom61()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    Point1.x = 265;
                    Point1.y = 140; //Point1 точка начала отрезка
                    Point2.x = 265;
                    Point2.y = par1.height-140; //Point2 точка конца отрезка                
                    
                    model1.x = 265 + 40; //отступы рисунка на заготовке
                    model1.y = 140;
                    model1.height = (par1.height - 280) / 4 - 30;
                    model1.width = (par1.height - 280) / 4 - 30;
                    model1.style = 1;
                    doc.ksRectangle(model1);

                    model2.x = model1.x; //отступы рисунка на заготовке
                    model2.y = model1.y + model1.height + 40;
                    model2.height = (par1.height - 280) / 4 - 30;
                    model2.width = (par1.height - 280) / 4 - 30;
                    model2.style = 1;
                    doc.ksRectangle(model2);

                    model3.x = model1.x; //отступы рисунка на заготовке
                    model3.y = model2.y + model2.height + 40;
                    model3.height = (par1.height - 280) / 4 - 30;
                    model3.width = (par1.height - 280) / 4 - 30;
                    model3.style = 1;
                    doc.ksRectangle(model3);

                    model4.x = model1.x; //отступы рисунка на заготовке
                    model4.y = model3.y + model3.height + 40;
                    model4.height = (par1.height - 280) / 4 - 30;
                    model4.width = (par1.height - 280) / 4 - 30;
                    model4.style = 1;
                    doc.ksRectangle(model4);

                    model5.x = par1.width - 140 -40 - model1.width; //отступы рисунка на заготовке
                    model5.y = 140;
                    model5.height = (par1.height - 280) / 4 - 30;
                    model5.width = (par1.height - 280) / 4 - 30;
                    model5.style = 1;
                    doc.ksRectangle(model5);

                    model6.x = par1.width - 140 - 40 - model1.width; //отступы рисунка на заготовке
                    model6.y = model5.y + model5.height + 40;
                    model6.height = (par1.height - 280) / 4 - 30;
                    model6.width = (par1.height - 280) / 4 - 30;
                    model6.style = 1;
                    doc.ksRectangle(model6);

                    model7.x = par1.width - 140 - 40 - model1.width; //отступы рисунка на заготовке
                    model7.y = model6.y + model6.height + 40;
                    model7.height = (par1.height - 280) / 4 - 30;
                    model7.width = (par1.height - 280) / 4 - 30;
                    model7.style = 1;
                    doc.ksRectangle(model7);

                    model8.x = par1.width - 140 - 40 - model1.width; //отступы рисунка на заготовке
                    model8.y = model7.y + model7.height + 40;
                    model8.height = (par1.height - 280) / 4 - 30;
                    model8.width = (par1.height - 280) / 4 - 30;
                    model8.style = 1;
                    doc.ksRectangle(model8);
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x + model1.width + 80, Point1.y, Point2.x + model1.width + 80, Point2.y, 1);
                    doc.ksLineSeg(par1.width - 140, Point1.y, par1.width - 140, Point2.y, 1);
                    doc.ksLineSeg(par1.width - model1.width -140 -80, Point1.y, par1.width - model1.width - 140 - 80, Point2.y, 1);
                    doc.ksLineSeg(Point1.x + model1.width + 80 +40, Point1.y, par1.width - 140 - 80 - model5.width -40, Point1.y, 1);
                    doc.ksLineSeg(Point1.x + model1.width + 80 + 40, Point1.y + (model1.width * 2)/3, par1.width - 140 - 80 - model5.width - 40, Point1.y+ (model1.width * 2) / 3, 1);
                    doc.ksLineSeg(Point1.x + model1.width + 80 + 40, Point1.y+ ((model1.width * 2) / 3)*2, par1.width - 140 - 80 - model5.width - 40, Point1.y+ ((model1.width * 2) / 3) * 2, 1);
                    doc.ksLineSeg(Point1.x + model1.width + 80 + 40, par1.height - 140, par1.width - 140 - 80 - model5.width - 40, par1.height - 140, 1);
                    doc.ksLineSeg(Point1.x + model1.width + 80 + 40, par1.height - ((model1.width * 2) / 3) - 140, par1.width - 140 - 80 - model5.width - 40, par1.height - ((model1.width * 2) / 3) -140, 1);
                    doc.ksLineSeg(Point1.x + model1.width + 80 + 40, par1.height - ((model1.width * 2) / 3) * 2 - 140, par1.width - 140 - 80 - model5.width - 40, par1.height - ((model1.width * 2) / 3) * 2 -140, 1);
                }
            }
        }
    

        public static void Econom62()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                
                {
                    Zagotovka(par1);
                    int _gradus1 = 250; double _radian1 = _gradus1 * Math.PI / 180;


                    doc.ksLineSeg(300, par1.height / 2, (par1.height)/2 + 300, par1.height / 2, 1);
                    reference _line1 = doc.ksLineSeg(300, par1.height / 2, (par1.height)/2 + 300, par1.height / 2, 1);
                    reference _line2 = doc.ksLineSeg(300, par1.height / 2, (par1.height)/2 + 300, par1.height / 2, 1);
                    doc.ksRotateObj(_line1,(par1.height) / 4 + 300, par1.height / 2, 60);
                    doc.ksRotateObj(_line2, (par1.height) / 4 + 300, par1.height / 2, 120);
                    reference _cir = doc.ksCircle((par1.height) / 4 + 300, par1.height / 2, (par1.height) / 4, 1);
                    doc.ksLine((par1.height) / 4 + 300, par1.height / 2, 50);
                    
                    //doc.ksArcByPoint((par1.height) / 4 + 300, par1.height / 2, (par1.height) / 4, 300, (par1.height) / 2,
                    //    ((par1.height) / 4)*Math.Cos(_radian1), ((par1.height) / 4) * Math.Sin(_radian1), 1, 1);

                    //xc, yc-координаты центра дуги,
                    //rad -радиус дуги,
                    //x1, y1 -координаты начальной точки дуги,
                    //x2, y2-координаты конечной точки дуги,
                    //direction-направление отрисовки дуги:1 - против часовой стрелки,-1 - по часовой стрелке,
                    //style-стиль линии.
                }
            }
        }//Пример поворота обьекта(на примере линии)Bug отрезать окружность и добавить симметрию (СМОТРИ МОДЕЛЬ 20)

        public static void Econom63()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 265; 
                    model1.y = 140;
                    model1.height = (par1.height - 280);
                    model1.width = (par1.width / 5);
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    doc.ksLineSeg(265 + model1.width + 130, 140, par1.width - 140 - 80, 140,1);
                    doc.ksLineSeg(265 + model1.width + 130, 140, 265 + model1.width + 130, par1.height-140, 1);
                    doc.ksLineSeg(265 + model1.width + 130, par1.height - 140, par1.width-140 - 80, par1.height - 140, 1);
                    double _rad1 = (par1.height - 280) / 2 - 65;
                    doc.ksLineSeg(265 + model1.width + 130,par1.height/2+65,par1.width-140-80-_rad1, par1.height / 2 + 65,1);
                    doc.ksLineSeg(265 + model1.width + 130, par1.height / 2 - 65, par1.width - 140-80 - _rad1, par1.height / 2 - 65, 1);
                    doc.ksArcBy3Points(par1.width - 140 - 80,140,par1.width-140,par1.height/2, par1.width - 140 - 80,par1.height-140,1);
                    doc.ksArcByPoint(par1.width - 140 - 80 - _rad1,par1.height-140,_rad1, par1.width - 140 - 80, par1.height - 140, par1.width - 140 - 80 - _rad1, par1.height / 2 + 65,-1,1);
                    doc.ksArcByPoint(par1.width - 140 - 80 - _rad1,140, _rad1, par1.width - 140 - 80,140, par1.width - 140 - 80 - _rad1, par1.height / 2 - 65,1,1);
                }
            }
        }

        public static void Econom64()
        {
        }

        public static void Econom65()
        {
        }

        public static void Econom66()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    
                    model1.x = 140; //отступы рисунка на заготовке
                    model1.y = 140;
                    model1.height = par1.height - 280;
                    model1.width = par1.width - 280;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    reference grpEco66 = doc.ksNewGroup(0);
                    doc.ksArcBy3Points(140, model1.height / 2 - 65 + 140, model1.width / 4, 226 + 140,
                        model1.width / 2 + 140, model1.height / 2 - 65 + 140, 1);
                    doc.ksArcBy3Points(140, model1.height / 2 + 65 + 140, model1.width / 4, 226 + 140 + 130,
                        model1.width / 2 + 140, model1.height / 2 + 65 + 140, 1);
                    //x1, y1 -координаты начальной точки на дуге
                    //x2, y2 - координаты средней точки на дуге,
                    //x3, y3 -координаты конечной точки на дуге
                    //style-стиль линии.
                    doc.ksEndGroup();
                    reference grpEco662 = doc.ksNewGroup(1);
                    doc.ksSymmetryObj(grpEco66, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 + 1,
                        "1");
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpEco662, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2, "1");
                    
                }
            }
        } //Arcby3points пример дуги по 3м точкам

        public static void Econom67()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                Zagotovka(par1);

                model1.x = 265;
                model1.y = 140;
                model1.height = ((par1.height - 280) - 160) / 3;
                model1.width = (par1.width - 405 - 160) / 3.5;
                model1.style = 1;
                doc.ksRectangle(model1);

                model2.x = 265 + model1.width + 80;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = (par1.width - 405 - 160) / 7;
                model2.style = 1;
                doc.ksRectangle(model2);

                model3.x = 265;
                model3.y = 140 + model1.height + 80;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = (par1.width - 405 - 160) / 3.5;
                model3.style = 1;
                doc.ksRectangle(model3);

                model4.x = 265 + model1.width + 80;
                model4.y = 140 + model1.height + 80;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = (par1.width - 405 - 160) / 7;
                model4.style = 1;
                doc.ksRectangle(model4);

                model5.x = 265;
                model5.y = 140 + model1.height * 2 + 80 * 2;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = (par1.width - 405 - 160) / 3.5;
                model5.style = 1;
                doc.ksRectangle(model5);

                model6.x = 265 + model1.width + 80;
                model6.y = 140 + model1.height * 2 + 80 * 2;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = (par1.width - 405 - 160) / 7;
                model6.style = 1;
                doc.ksRectangle(model6);


                double rad1 = (par1.width - 140 - 265 - 80 * 2 - model1.width - model2.width) / 2;
                reference auxcircle = doc.ksCircle(265 + model1.width + model2.width + 80 * 2 + rad1,
                    par1.height / 2, rad1, 1);

                mat.ksIntersectLinSCir(par1.width, 140, 265 + model1.width + model2.width + 80 * 2 + rad1,
                   140, 265 + model1.width + model2.width + 80 * 2 + rad1, par1.height / 2, rad1, arr);//Получаем расстояние от заданой точки до точки пересечения
                GetPoint(arr, par);//записываем координаты точки пересечения в массив
                double px1 = par.x;
                double py1 = par.y;
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model2.width, 140, par.x, 140, 1);//Рисуем линию от заданой точки до точки пересечения

                mat.ksIntersectLinSCir(par1.width, 140 + model1.height,
                    265 + model1.width + model2.width + 80 * 2 + rad1, 140 + model1.height,
                    265 + model1.width + model2.width + 80 * 2 + rad1, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model2.width, 140 + model1.height, par.x,
                    140 + model1.height, 1);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model2.width, 140,
                    265 + 80 * 2 + model1.width + model2.width, 140 + model1.height, 1);
                double px2 = par.x;
                double py2 = par.y;

                mat.ksIntersectLinSCir(par1.width, 140 + model1.height + 80,
                    265 + model1.width + model2.width + 80 * 2 + rad1, 140 + model1.height + 80,
                    265 + model1.width + model2.width + 80 * 2 + rad1, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model2.width, 140 + model1.height + 80, par.x, par.y, 1);
                double px3 = par.x;
                double py3 = par.y;

                mat.ksIntersectLinSCir(par1.width, 140 + model1.height*2 + 80,
                    265 + model1.width + model2.width + 80 * 2 + rad1, 140 + model1.height*2 + 80,
                    265 + model1.width + model2.width + 80 * 2 + rad1, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model2.width, 140 + model1.height*2 + 80, par.x, par.y, 1);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model2.width, 140 + model1.height + 80,
                    265 + 80 * 2 + model1.width + model2.width, 140 + model1.height * 2 + 80, 1);
                double px4 = par.x;
                double py4 = par.y;

                mat.ksIntersectLinSCir(par1.width, 140 + model1.height*2 + 80*2,
                    265 + model1.width + model2.width + 80 * 2 + rad1, 140 + model1.height*2 + 80*2,
                    265 + model1.width + model2.width + 80 * 2 + rad1, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model2.width, 140 + model1.height*2 + 80*2, par.x, par.y, 1);
                double px5 = par.x;
                double py5 = par.y;

                mat.ksIntersectLinSCir(par1.width, 140 + model1.height*3 + 80*2,
                    265 + model1.width + model2.width + 80 * 2 + rad1, 140 + model1.height*3 + 80*2,
                    265 + model1.width + model2.width + 80 * 2 + rad1, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model2.width, 140 + model1.height*3 + 80*2, par.x, par.y, 1);
                doc.ksLineSeg(265 + 80 * 2 + model1.width + model2.width, 140 + model1.height * 2 + 80 * 2,
                    265 + 80 * 2 + model1.width + model2.width, 140 + model1.height * 3 + 80 * 2, 1);
                double px6 = par.x;
                double py6 = par.y;
                reference curve1 = doc.ksArcBy3Points(px1, py1, par1.width - 140, par1.height / 2, px6, py6, 1);
                doc.ksDeleteObj(auxcircle);
                doc.ksTrimmCurve(curve1, px1, py1, px2, py2, px2, py2, 0);
                doc.ksTrimmCurve(curve1, px3, py3, px4, py4, px4, py4, 0);
                doc.ksTrimmCurve(curve1, px5, py5, px6, py6, px6, py6, 1);
            }
        }//пример вычесления от точки до окружности(mat.ksIntersectLinSCir) предварительно объяви ksDynamicArray arr и ksMathPointParam par



        public static void Econom68()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                Zagotovka(par1);

                model1.x = 265;
                model1.y = 140;
                model1.height = par1.height - 280;
                model1.width = (par1.height / 10) * 3;
                model1.style = 1;
                doc.ksRectangle(model1);

                model2.x = 265 + model1.width + 80;
                model2.y = 140;
                model2.height = ((par1.height - 280) - 160) / 3;
                model2.width = (par1.width - 405 - 240-model1.width) / 3;
                model2.style = 1;
                doc.ksRectangle(model2);

                model3.x = 265 + model1.width + 80 * 2 + model2.width;
                model3.y = 140;
                model3.height = ((par1.height - 280) - 160) / 3;
                model3.width = (par1.width - 405 - 240 - model1.width) / 3;
                model3.style = 1;
                doc.ksRectangle(model3);

                model4.x = 265 + model1.width + 80;
                model4.y = 140 + model2.height + 80;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = (par1.width - 405 - 240 - model1.width) / 3;
                model4.style = 1;
                doc.ksRectangle(model4);

                model5.x = 265 + model1.width + 80 * 2 + model2.width;
                model5.y = 140 + model2.height  + 80;
                model5.height = ((par1.height - 280) - 160) / 3;
                model5.width = (par1.width - 405 - 240 - model1.width) / 3;
                model5.style = 1;
                doc.ksRectangle(model5);

                model6.x = 265 + model1.width + 80;
                model6.y = 140 + model2.height * 2 + 80 * 2;
                model6.height = ((par1.height - 280) - 160) / 3;
                model6.width = (par1.width - 405 - 240 - model1.width) / 3;
                model6.style = 1;
                doc.ksRectangle(model6);

                model7.x = 265 + model1.width + 80 * 2 + model2.width;
                model7.y = 140 + model2.height * 2 + 80 * 2;
                model7.height = ((par1.height - 280) - 160) / 3;
                model7.width = (par1.width - 405 - 240 - model1.width) / 3;
                model7.style = 1;
                doc.ksRectangle(model7);

                double rad1 = par1.width - 405 - 160 - model1.width - model2.width * 2;
                reference auxcircle = doc.ksCircle(par1.width - 140 - 80 - model2.width, par1.height / 2, rad1, 1);

                mat.ksIntersectLinSCir(par1.width, 140,par1.width-140-rad1/2,140, par1.width - 140 - 80 - model2.width, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265+model1.width+model2.width*2+80*3,140, par.x, par.y, 1);
                double px1 = par.x;
                double py1 = par.y;

                mat.ksIntersectLinSCir(par1.width, 140 + model2.height, par1.width - 140 - rad1 / 2,
                    140 + model2.height, par1.width - 140 - 80 - model2.width, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height, par.x, par.y, 1);
                doc.ksLineSeg(265 + model1.width + model2.width * 2 + 80 * 3, 140,
                    265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height, 1);
                double px2 = par.x;
                double py2 = par.y;

                mat.ksIntersectLinSCir(par1.width, 140 + model2.height+80, par1.width - 140 - rad1 / 2,
                    140 + model2.height+80, par1.width - 140 - 80 - model2.width, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height+80, par.x, par.y, 1);
                double px3 = par.x;
                double py3 = par.y;

                mat.ksIntersectLinSCir(par1.width, 140 + model2.height*2 + 80, par1.width - 140 - rad1 / 2,
                    140 + model2.height*2 + 80, par1.width - 140 - 80 - model2.width, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height*2 + 80, par.x, par.y, 1);
                doc.ksLineSeg(265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height + 80,
                    265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height * 2 + 80, 1);
                double px4 = par.x;
                double py4 = par.y;

                mat.ksIntersectLinSCir(par1.width, 140 + model2.height*2 + 80*2, par1.width - 140 - rad1 / 2,
                    140 + model2.height*2 + 80*2, par1.width - 140 - 80 - model2.width, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height * 2 + 80 * 2, par.x,
                    par.y, 1);
                double px5 = par.x;
                double py5 = par.y;

                mat.ksIntersectLinSCir(par1.width, 140 + model2.height * 3 + 80 * 2, par1.width - 140 - rad1 / 2,
                    140 + model2.height * 3 + 80 * 2, par1.width - 140 - 80 - model2.width, par1.height / 2, rad1, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height * 3 + 80 * 2, par.x, par.y, 1);
                doc.ksLineSeg(265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height * 2 + 80 * 2,
                    265 + model1.width + model2.width * 2 + 80 * 3, 140 + model2.height * 3 + 80 * 2, 1);
                double px6 = par.x;
                double py6 = par.y;

                reference curve1 = doc.ksArcBy3Points(px1, py1, par1.width - 140, par1.height / 2, px6, py6, 1);
                doc.ksDeleteObj(auxcircle);
                doc.ksTrimmCurve(curve1, px1, py1, px2, py2, px2, py2, 0);
                doc.ksTrimmCurve(curve1, px3, py3, px4, py4, px4, py4, 0);
                doc.ksTrimmCurve(curve1, px5, py5, px6, py6, px6, py6, 1);
            }

        }

        public static void Econom69()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                Zagotovka(par1);
                model1.x = 265;
                model1.y = 140;
                model1.height = par1.height - 280;
                model1.width = (par1.height / 10) * 3;
                model1.style = 1;
                doc.ksRectangle(model1);
                
                model4.x = 265 + model1.width + 130;
                model4.y = 140;
                model4.height = par1.height / 10;
                model4.width = (par1.width + 100) / 3;
                model4.style = 1;
                doc.ksRectangle(model4);

                model5.x = 265 + model1.width + 130;
                model5.y = par1.height - 140 - model4.height;
                model5.height = par1.height / 10;
                model5.width = (par1.width + 100) / 3;
                model5.style = 1;
                doc.ksRectangle(model5);

                doc.ksLineSeg(265 + model1.width + 130, 140 + model4.height + 130,
                    265 + model1.width + 130 + (par1.width - 50) / 3, 140 + model4.height + 130, 1);
                doc.ksLineSeg(265 + model1.width + 130, 140 + model4.height + 130, 265 + model1.width + 130,
                    par1.height - 140 - model4.height - 130, 1);
                doc.ksLineSeg(265 + model1.width + 130, par1.height - 140 - model4.height - 130,
                    265 + model1.width + 130 + (par1.width - 50) / 3, par1.height - 140 - model4.height - 130, 1);
                doc.ksLineSeg(265 + model1.width + 130 + (par1.width - 50) / 3, par1.height - 140 - model4.height - 130,
                    265 + model1.width + 130 + (par1.width - 50) / 3, 140 + model4.height + 130, 1);

                doc.ksLineSeg(265 + model1.width + 130 * 2 + (par1.width - 50) / 3, 140 + model4.height + 130,
                    265 + model1.width + 130 * 2 + (par1.width + 25) / 27 + (par1.width - 50) / 3,
                    140 + model4.height + 130, 1);
                doc.ksLineSeg(265 + model1.width + 130 * 2 + (par1.width - 50) / 3, 140 + model4.height + 130,
                    265 + model1.width + 130 * 2 + (par1.width - 50) / 3, par1.height - 140 - model5.height - 130, 1);
                doc.ksLineSeg(265 + model1.width + 130 * 2 + (par1.width - 50) / 3,
                    par1.height - 140 - model5.height - 130,
                    265 + model1.width + 130 * 2 + (par1.width + 25) / 27 + (par1.width - 50) / 3,
                    par1.height - 140 - model5.height - 130, 1);

                doc.ksLineSeg(265 + model1.width + 130 * 2 + model4.width, 140, par1.width - 140, 140, 1);
                doc.ksLineSeg(265 + model1.width + 130 * 2 + model4.width, 140,
                    265 + model1.width + 130 * 2 + model4.width, 140 + model4.height, 1);
                doc.ksLineSeg(265 + model1.width + 130 * 2 + model4.width, 140 + model4.height,
                    265 + model1.width + 130 * 2 + model4.width+((par1.width + 25) / 27) / 3, 140 + model4.height, 1);
                doc.ksLineSeg(par1.width - 140, 140, par1.width - 140, 140 + model4.height + 130, 1);

                doc.ksLineSeg(265 + model1.width + 130 * 2 + model4.width, par1.height - 140, par1.width - 140,
                    par1.height - 140, 1);
                doc.ksLineSeg(265 + model1.width + 130 * 2 + model4.width, par1.height - 140,
                    265 + model1.width + 130 * 2 + model4.width, par1.height - 140 - model5.height, 1);
                doc.ksLineSeg(265 + model1.width + 130 * 2 + model4.width, par1.height - 140 - model5.height,
                    265 + model1.width + 130 * 2 + model4.width+((par1.width + 25) / 27) / 3, par1.height - 140 - model5.height, 1);
                doc.ksLineSeg(par1.width - 140, par1.height - 140, par1.width - 140,
                    par1.height - 140 - model5.height - 130, 1);

                double rad1 = (par1.height - 140 * 2 - model4.height * 2 - 130 * 2) / 2;
                doc.ksArcBy3Points(265 + model1.width + 130 * 2 + (par1.width - 50) / 3 + ((par1.width + 25) / 27),
                    140 + model4.height + 130,
                    265 + model1.width + 130 * 2 + (par1.width - 50) / 3 + ((par1.width + 25) / 27) + rad1, par1.height / 2,
                    265 + model1.width + 130 * 2 + (par1.width - 50) / 3 + ((par1.width + 25) / 27),
                    par1.height - 140 - model5.height - 130, 1);

                reference curve1 = doc.ksArcByPoint(
                    265 + model1.width + 130 * 2 + (par1.width - 50) / 3 + ((par1.width + 25) / 27), par1.height / 2,
                    rad1 + 130, 265 + model1.width + 130 * 2 + model4.width + ((par1.width + 25) / 27) / 3,
                    140 + model4.height, 265 + model1.width + 130 * 2 + model4.width + ((par1.width + 25) / 27) / 3,
                    par1.height - 140 - model5.height, 1, 1);
                reference auxcircle = doc.ksCircle(
                    265 + model1.width + 130 * 2 + (par1.width - 50) / 3 + ((par1.width + 25) / 27), par1.height / 2,
                    rad1 + 130, 1);

                mat.ksIntersectLinSCir(par1.width, 140 + model4.height + 130,
                    265 + model1.width + 130 * 2 + (par1.width - 50) / 3 + ((par1.width + 25) / 27),
                    140 + model4.height + 130,
                    265 + model1.width + 130 * 2 + (par1.width - 50) / 3 + ((par1.width + 25) / 27), par1.height / 2,
                    rad1+130, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width-140, 140 + model4.height + 130, par.x, par.y, 1);
                double px1 = par.x;
                double py1 = par.y;

                mat.ksIntersectLinSCir(par1.width, par1.height - 140 - model5.height - 130,
                    265 + model1.width + 130 * 2 + (par1.width - 50) / 3 + ((par1.width + 25) / 27),
                    par1.height - 140 - model5.height - 130,
                    265 + model1.width + 130 * 2 + (par1.width - 50) / 3 + ((par1.width + 25) / 27), par1.height / 2,
                    rad1+130, arr);
                GetPoint(arr, par);
                doc.ksLineSeg(par1.width - 140, par1.height - 140 - model5.height - 130, par.x, par.y, 1);
                double px2 = par.x;
                double py2 = par.y;
                doc.ksDeleteObj(auxcircle);
                doc.ksTrimmCurve(curve1,
                    265 + model1.width + 130 * 2 + model4.width + ((par1.width + 25) / 27) / 3,
                    140 + model4.height,px1, py1, px1, py1, 0);
                doc.ksTrimmCurve(curve1, px2, py2,
                    265 + model1.width + 130 * 2 + model4.width + ((par1.width + 25) / 27) / 3,
                    par1.height - 140 - model5.height,
                    265 + model1.width + 130 * 2 + model4.width + ((par1.width + 25) / 27) / 3,
                    par1.height - 140 - model5.height, 1); 
            }
        }
        

        public static void Econom70()
        {
        }

        public static void Econom71()
        {
        }

        public static void Econom72()
        {
        }

        public static void Econom73()
        {
            doc = (ksDocument2D) kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short) DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 265; //отступы рисунка на заготовке
                    model1.y = 140;
                    model1.height = par1.height - 280;
                    model1.width = par1.width - 405;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    Point1.x = model1.width / 3 + 265;
                    Point1.y = 140; //Point1 точка начала отрезка
                    Point2.x = model1.width / 3 + 265;
                    Point2.y = par1.height - 140; //Point2 точка конца отрезка                
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg(Point1.x + model1.width / 3, Point1.y, Point2.x + model1.width / 3, Point2.y, 1);
                    doc.ksLineSeg(model1.width / 6 + 265 + 40, Point1.y, model1.width / 6 + 265 + 40, Point2.y, 1);
                    doc.ksLineSeg(model1.width / 6 + 265 - 40, Point1.y, model1.width / 6 + 265 - 40, Point2.y, 1);
                    doc.ksLineSeg((model1.width / 6) * 3 + 265 - 40, Point1.y, (model1.width / 6) * 3 + 265 - 40,
                        Point2.y, 1);
                    doc.ksLineSeg((model1.width / 6) * 3 + 265 + 40, Point1.y, (model1.width / 6) * 3 + 265 + 40,
                        Point2.y, 1);
                    doc.ksLineSeg((model1.width / 6) * 5 + 265 - 40, Point1.y, (model1.width / 6) * 5 + 265 - 40,
                        Point2.y, 1);
                    doc.ksLineSeg((model1.width / 6) * 5 + 265 + 40, Point1.y, (model1.width / 6) * 5 + 265 + 40,
                        Point2.y, 1);
                }
            }
        }

        public static void Econom74()
        {
        }

        public static void Econom75()
        {
        }

        public static void Econom76()
        {
        }

        public static void Econom77()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 140;
                    model1.y = 140;
                    model1.height = par1.height - 280;
                    model1.width = par1.width - 280;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    Point1.y = (par1.height - 280) / 5;//Длинные вертикальные линии
                    doc.ksLineSeg(140, Point1.y + 140, par1.width - 140, Point1.y + 140, 1);
                    doc.ksLineSeg(140, Point1.y*2 + 140, par1.width - 140, Point1.y*2 + 140, 1);
                    doc.ksLineSeg(140, Point1.y*3 + 140, par1.width - 140, Point1.y*3 + 140, 1);
                    doc.ksLineSeg(140, Point1.y*4 + 140, par1.width - 140, Point1.y*4 + 140, 1);
                    if (Visota >= 950)
                    {
                        Point1.x = (par1.width - 280) / 12;
                        for (int i = 1; i <= 11; i++)
                        {
                            doc.ksLineSeg(Point1.x*i + 140, 140, Point1.x*i + 140, par1.height - 140, 1);
                        }
                    }
                    else if (Visota >= 850 && Visota < 950)
                    {
                        Point1.x = (par1.width - 280) / 14;
                        for (int i = 1; i <= 13; i++)
                        {
                            doc.ksLineSeg(Point1.x * i + 140, 140, Point1.x * i + 140, par1.height - 140, 1);
                        }
                    }
                    else if (Visota >= 750 && Visota < 850)
                    {
                        Point1.x = (par1.width - 280) / 16;
                        for (int i = 1; i <= 15; i++)
                        {
                            doc.ksLineSeg(Point1.x * i + 140, 140, Point1.x * i + 140, par1.height - 140, 1);
                        }
                    }
                    else if (Visota >= 650 && Visota < 750)
                    {
                        Point1.x = (par1.width - 280) / 18;
                        for (int i = 1; i <= 17; i++)
                        {
                            doc.ksLineSeg(Point1.x * i + 140, 140, Point1.x * i + 140, par1.height - 140, 1);
                        }
                    }
                    else
                    {
                        Point1.x = (par1.width - 280) / 20;
                        for (int i = 1; i <= 19; i++)
                        {
                            doc.ksLineSeg(Point1.x * i + 140, 140, Point1.x * i + 140, par1.height - 140, 1);
                        }
                    }
                }
            }
        }//Цикличная отрисовка Bug переделать алгоритм.

        public static void Econom78()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 265+24.85;//24.85 подстройка при развороте куба(высота треугольника выходящего за периметр)
                    model1.y = 140+24.85;
                    model1.height = 120;
                    model1.width = 120;
                    model1.style = 1;
                    reference _cube1 = doc.ksRectangle(model1);
                    doc.ksRotateObj(_cube1,265+60+ 24.85, 140+60+ 24.85, 45);
                    doc.ksCopyObj(_cube1, 265, 140 + 80.71, 169.71 + 80+265, 140 + 80.71, 1,0);
                    doc.ksCopyObj(_cube1, 265, 140 + 80.71, 169.71*2 + 80*2 + 265, 140 + 80.71, 1, 0);
                    doc.ksCopyObj(_cube1, 265+169.71, 140 + 80.71, par1.width-140, 140 + 80.71, 1, 0);
                    doc.ksCopyObj(_cube1, 265 + 169.71, 140 + 80.71, par1.width - 140-169.71-80, 140 + 80.71, 1, 0);
                    reference grpEco78 = doc.ksNewGroup(0);
                    doc.ksLineSeg(0, par1.height - 200, par1.width / 2 - 210, par1.height - 200, 1);
                    doc.ksLineSeg(par1.width/2-150, par1.height-260,par1.width/2, par1.height - 260,1);
                    doc.ksLineSeg(par1.width / 2 - 210, par1.height - 200, par1.width / 2 - 150, par1.height - 260,1);
                    doc.ksLineSeg(0, par1.height - 140, par1.width / 2 - 185.15, par1.height - 140,1);
                    doc.ksLineSeg(par1.width/2-125.15,par1.height-200,par1.width/2, par1.height - 200,1);
                    doc.ksLineSeg(par1.width / 2 - 185.15, par1.height - 140, par1.width / 2 - 125.15, par1.height - 200,1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpEco78, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 + 1,
                        "1");
                }
            }
        }

        public static void Econom79()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 265; 
                    model1.y = 140;
                    model1.height = (par1.height / 2 - 180);
                    model1.width = (par1.width - 265 - 140 - 80 * 3) / 4;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    model2.x = (model1.width + 80 + 265);
                    model2.y = 140;
                    model2.height = (par1.height / 2 - 180);
                    model2.width = (par1.width - 265 - 140 - 80 * 3) / 4;
                    model2.style = 1;
                    doc.ksRectangle(model2);
                    model3.x = (model1.width*2 + 80*2 + 265);
                    model3.y = 140;
                    model3.height = (par1.height / 2 -180);
                    model3.width = (par1.width - 265 - 140 - 80 * 3) / 4;
                    model3.style = 1;
                    doc.ksRectangle(model3);
                    model4.x = 265;
                    model4.y = par1.height/2+40;
                    model4.height = (par1.height/2 - 180);
                    model4.width = (par1.width - 265 - 140 - 80 * 3) / 4;
                    model4.style = 1;
                    doc.ksRectangle(model4);
                    model5.x = (model1.width + 80 + 265);
                    model5.y = par1.height / 2 + 40;
                    model5.height = (par1.height/2 - 180);
                    model5.width = (par1.width - 265 - 140 - 80 * 3) / 4;
                    model5.style = 1;
                    doc.ksRectangle(model5);
                    model6.x = (model1.width * 2 + 80 * 2 + 265);
                    model6.y = par1.height / 2 + 40;
                    model6.height = (par1.height/2 - 180);
                    model6.width = (par1.width - 265 - 140 - 80 * 3) / 4;
                    model6.style = 1;
                    doc.ksRectangle(model6);
                    doc.ksLineSeg(265 + model1.width * 3 + 80 * 3, 140,265 + model1.width * 3 + 80 * 3+model1.width-80,140,1);
                    doc.ksLineSeg(265 + model1.width * 3 + 80 * 3, 140, 265 + model1.width * 3 + 80 * 3, par1.height / 2 - 40,1);
                    doc.ksLineSeg(265 + model1.width * 3 + 80 * 3, par1.height / 2 - 40,par1.width-140, par1.height / 2 - 40,1);
                    doc.ksLineSeg(265 + model1.width * 3 + 80 * 3, par1.height/2+40, par1.width - 140, par1.height / 2 + 40, 1);
                    doc.ksLineSeg(265 + model1.width * 3 + 80 * 3, par1.height / 2 + 40, 265 + model1.width * 3 + 80 * 3,par1.height-140,1);
                    doc.ksLineSeg(265 + model1.width * 3 + 80 * 3, par1.height - 140, 265 + model1.width * 3 + 80 * 3 + model1.width - 80, par1.height - 140, 1);
                    doc.ksArcBy3Points(265 + model1.width * 3 + 80 * 3 + model1.width - 80, 140, 265 + model1.width * 3 + 80 * 3 + model1.width-13, par1.height/3, par1.width - 140, par1.height / 2 - 40, 1);
                    doc.ksArcBy3Points(par1.width - 140, par1.height / 2 + 40, 265 + model1.width * 3 + 80 * 3 + model1.width-13, (par1.height*2) / 3, 265 + model1.width * 3 + 80 * 3 + model1.width - 80, par1.height - 140, 1);
                }
            }
        }

        public static void Econom80()
        {
        }

        public static void Econom81()
        {
        }

        public static void Econom82()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    model1.x = 265; 
                    model1.y = 140;
                    model1.height = (par1.height - 280);
                    model1.width = (par1.width -265*2-80*4)/5;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    model2.x = (model1.width + 80 + 265);
                    model2.y = 140;
                    model2.height = (par1.height - 280);
                    model2.width = (par1.width - 265 * 2 - 80 * 4) / 5;
                    model2.style = 1;
                    doc.ksRectangle(model2);
                    model3.x = (model1.width*2 + 80*2 + 265);
                    model3.y = 140;
                    model3.height = (par1.height - 280);
                    model3.width = (par1.width - 265 * 2 - 80 * 4) / 5;
                    model3.style = 1;
                    doc.ksRectangle(model3);
                    model4.x = (model1.width*3 + 80*3 + 265);
                    model4.y = 140;
                    model4.height = (par1.height - 280);
                    model4.width = (par1.width - 265 * 2 - 80 * 4) / 5;
                    model4.style = 1;
                    doc.ksRectangle(model4);
                    model5.x = (model1.width*4 + 80*4 + 265);
                    model5.y = 140;
                    model5.height = (par1.height - 280);
                    model5.width = (par1.width - 265 * 2 - 80 * 4) / 5;
                    model5.style = 1;
                    doc.ksRectangle(model5);
                }
            }
        }

        public static void Econom83()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    reference grpEco83 = doc.ksNewGroup(0);
                    doc.ksLineSeg(140,140,par1.width/2-100,140, 1);
                    doc.ksLineSeg(par1.width/2 - 100, 140, par1.width/2, 140+100, 1);
                    doc.ksLineSeg(140+100, 140+80, par1.width/2 - 100 -33.14, 140+80, 1);
                    doc.ksLineSeg(par1.width/2 - 100 - 33.14, 140+80, par1.width / 2, 140+113.14+100, 1);//
                    doc.ksLineSeg(140 + 200, 140 + 160, par1.width/2 - 100 - 33.14*2, 140 + 160, 1);
                    doc.ksLineSeg(par1.width/2 - 100 - 33.14 * 2, 140 + 160, par1.width / 2, 140 + 100+113.14*2, 1);//
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpEco83, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2+1,
                        "1");             
                }
            }
        }

        #endregion

        #region =======================V классика=======================

        public static void Vclassic1()
        {
        }

        public static void Vclassic2()
        {
        }

        public static void Vclassic3()
        {
        }

        public static void Vclassic4()
        {
        }

        public static void Vclassic5()
        {
        }

        public static void Vclassic6()
        {
        }

        public static void Vclassic7()
        {
        }

        public static void Vclassic8()
        {
        }

        public static void Vclassic9()
        {
        }

        public static void Vclassic10()
        {
        }

        public static void Vclassic11()
        {
        }

        public static void Vclassic12()
        {
        }

        public static void Vclassic13()
        {
        }

        public static void Vclassic14()
        {
        }

        public static void Vclassic15()
        {
        }

        public static void Vclassic16()
        {
        }

        public static void Vclassic17()
        {
        }

        public static void Vclassic18()
        {
        }

        public static void Vclassic19()
        {
        }

        public static void Vclassic20()
        {
        }

        public static void Vclassic21()
        {
        }

        public static void Vclassic22()
        {
        }

        public static void Vclassic23()
        {
        }

        public static void Vclassic24()
        {
        }

        public static void Vclassic25()
        {
        }

        public static void Vclassic26()
        {
        }

        public static void Vclassic27()
        {
        }

        public static void Vclassic28()
        {
        }

        public static void Vclassic29()
        {
        }

        public static void Vclassic30()
        {
        }

        public static void Vclassic31()
        {
        }

        public static void Vclassic32()
        {
        }

        public static void Vclassic33()
        {
        }

        public static void Vclassic34()
        {
        }

        public static void Vclassic35()
        {
        }

        public static void Vclassic36()
        {
        }

        public static void Vclassic37()
        {
        }

        public static void Vclassic38()
        {
        }

        public static void Vclassic39()
        {
        }

        public static void Vclassic40()
        {
        }

        public static void Vclassic41()
        {
        }

        public static void Vclassic42()
        {
        }

        public static void Vclassic43()
        {
        }

        public static void Vclassic44()
        {
        }

        public static void Vclassic45()
        {
        }

        public static void Vclassic46()
        {
        }

        public static void Vclassic47()
        {
        }

        public static void Vclassic48()
        {
        }

        public static void Vclassic49()
        {
        }

        public static void Vclassic50()
        {
        }

        public static void Vclassic51()
        {
        }

        public static void Vclassic52()
        {
        }

        public static void Vclassic53()
        {
        }

        public static void Vclassic54()
        {
        }

        public static void Vclassic55()
        {
        }

        public static void Vclassic56()
        {
        }

        public static void Vclassic57()
        {
        }

        public static void Vclassic58()
        {
        }

        public static void Vclassic59()
        {
        }

        public static void Vclassic60()
        {
        }

        public static void Vclassic61()
        {
        }

        public static void Vclassic62()
        {
        }

        public static void Vclassic63()
        {
        }

        public static void Vclassic64()
        {
        }

        public static void Vclassic65()
        {
        }

        public static void Vclassic66()
        {
        }

        public static void Vclassic67()
        {
        }

        public static void Vclassic68()
        {
        }

        public static void Vclassic69()
        {
        }

        public static void Vclassic70()
        {
        }

        public static void Vclassic71()
        {
        }

        public static void Vclassic72()
        {
        }

        public static void Vclassic73()
        {
        }

        public static void Vclassic74()
        {
        }

        public static void Vclassic75()
        {
        }

        public static void Vclassic76()
        {
        }

        public static void Vclassic77()
        {
        }

        public static void Vclassic78()
        {
        }

        public static void Vclassic79()
        {
        }

        public static void Vclassic80()
        {
        }

        public static void Vclassic81()
        {
        }

        public static void Vclassic82()
        {
        }

        public static void Vclassic83()
        {
        }

        public static void Vclassic84()
        {
        }

        public static void Vclassic85()
        {
        }

        public static void Vclassic86()
        {
        }

        public static void Vclassic87()
        {
        }

        public static void Vclassic88()
        {
        }

        public static void Vclassic89()
        {
        }

        public static void Vclassic90()
        {
        }

        public static void Vclassic91()
        {
        }

        public static void Vclassic92()
        {
        }

        public static void Vclassic93()
        {
        }

        public static void Vclassic94()
        {
        }

        public static void Vclassic95()
        {
        }

        public static void Vclassic96()
        {
        }

        public static void Vclassic97()
        {
        }

        public static void Vclassic98()
        {
        }

        public static void Vclassic99()
        {
        }

        public static void Vclassic100()
        {
        }

        public static void Vclassic101()
        {
        }

        public static void Vclassic102()
        {
        }

        public static void Vclassic103()
        {
        }

        public static void Vclassic104()
        {
        }

        public static void Vclassic105()
        {
        }

        public static void Vclassic106()
        {
        }

        public static void Vclassic107()
        {
        }

        public static void Vclassic108()
        {
        }

        public static void Vclassic109()
        {
        }

        public static void Vclassic110()
        {
        }

        public static void Vclassic111()
        {
        }

        public static void Vclassic112()
        {
        }

        public static void Vclassic113()
        {
        }

        public static void Vclassic114()
        {
        }

        public static void Vclassic115()
        {
        }

        public static void Vclassic116()
        {
        }

        public static void Vclassic117()
        {
        }

        public static void Vclassic118()
        {
        }

        public static void Vclassic119()
        {
        }

        public static void Vclassic120()
        {
        }

        public static void Vclassic121()
        {
        }

        public static void Vclassic122()
        {
        }

        public static void Vclassic123()
        {
        }

        #endregion

        #region ----------------------Facade-----------------------

        public static void ArcaDv()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - IndentY;
                    doc.ksArcByPoint(par1.width - IndentX - rad1, par1.height / 2, rad1, par1.width - IndentX - rad1,
                        IndentY, par1.width - IndentX - rad1, par1.height - IndentY, 1, 1);
                    doc.ksArcByPoint(IndentX + rad1, par1.height / 2, rad1, IndentX + rad1, IndentY, IndentX + rad1,
                        par1.height - IndentY, -1, 1);
                    doc.ksLineSeg(IndentX + rad1, IndentY, par1.width - IndentX - rad1, IndentY, 1);
                    doc.ksLineSeg(IndentX + rad1, par1.height - IndentY, par1.width - IndentX - rad1,
                        par1.height - IndentY, 1);
                }
            }
        }
        public static void ArcaOd()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - IndentY;
                    doc.ksArcByPoint(par1.width - IndentX - rad1, par1.height / 2, rad1, par1.width - IndentX - rad1,
                        IndentY, par1.width - IndentX - rad1, par1.height - IndentY, 1, 1);
                    doc.ksLineSeg(IndentX, IndentY, IndentX, par1.height - IndentY, 1);
                    doc.ksLineSeg(IndentX, IndentY, par1.width - IndentX - rad1, IndentY, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY, par1.width - IndentX - rad1, par1.height - IndentY,
                        1);
                }
            }
        }
        public static void Kvadrat()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    //создание заготовки
                    model1.x = IndentX; //отступы рисунка на заготовке
                    model1.y = IndentY;
                    model1.height = par1.height - IndentY*2;
                    model1.width = par1.width - IndentX*2;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                }
            }
        }
        public static void Vosmiugolnik()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(IndentX, IndentY + 42.43, IndentX + 42.43, IndentY, 1);
                    doc.ksLineSeg(IndentX, IndentY + 42.43, IndentX, par1.height - IndentY - 42.43, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY - 42.43, IndentX + 42.43, par1.height - IndentY, 1);
                    doc.ksLineSeg(IndentX + 42.43, par1.height - IndentY, par1.width - IndentX - 42.43,
                        par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX - 42.43, par1.height - IndentY, par1.width - IndentX,
                        par1.height - IndentY - 42.43, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height - IndentY - 42.43, par1.width - IndentX,
                        IndentY + 42.43, 1);
                    doc.ksLineSeg(par1.width - IndentX, IndentY + 42.43, par1.width - IndentX - 42.43, IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX - 42.43, IndentY, IndentX + 42.43, IndentY, 1);
                    //Все фаски сделаны под 45 градусов длиной 60мм в дальнейшем,если понадобится, переделать под настраиваемую пользователем
                }
            }
        }
        public static void Tango()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = (par1.height / 2 - IndentY) - (par1.height / 2 - IndentY) * 0.57;
                    doc.ksArcByPoint(IndentX, IndentY, rad1, IndentX, IndentY + rad1, IndentX + rad1, IndentY, -1, 1);
                    doc.ksLineSeg(IndentX, IndentY + rad1, IndentX, par1.height - IndentY - rad1, 1);
                    doc.ksArcByPoint(IndentX, par1.height - IndentY, rad1, IndentX + rad1, par1.height - IndentY,
                        IndentX, par1.height - IndentY - rad1, -1, 1);
                    doc.ksLineSeg(IndentX + rad1, par1.height - IndentY, par1.width - IndentX - rad1,
                        par1.height - IndentY, 1);
                    doc.ksArcByPoint(par1.width - IndentX, par1.height - IndentY, rad1, par1.width - IndentX - rad1,
                        par1.height - IndentY, par1.width - IndentX, par1.height - IndentY - rad1, 1, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height - IndentY - rad1, par1.width - IndentX,
                        IndentY + rad1, 1);
                    doc.ksArcByPoint(par1.width - IndentX, IndentY, rad1, par1.width - IndentX, IndentY + rad1,
                        par1.width - IndentX - rad1, IndentY, 1, 1);
                    doc.ksLineSeg(par1.width - IndentX - rad1, IndentY, IndentX + rad1, IndentY, 1);
                }
            }
            //радиус изменяется, изменить если надо на статичный
        }
        public static void Elegant()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 11;
                    doc.ksArcBy3Points(IndentX + rad1, IndentY, IndentX, par1.height / 2, IndentX + rad1,
                        par1.height - IndentY, 1);
                    doc.ksLineSeg(IndentX + rad1, IndentY, par1.width - IndentX - rad1, IndentY, 1);
                    doc.ksLineSeg(IndentX + rad1, par1.height - IndentY, par1.width - IndentX - rad1,
                        par1.height - IndentY, 1);
                    doc.ksArcBy3Points(par1.width - IndentX - rad1, par1.height - IndentY, par1.width - IndentX,
                        par1.height / 2, par1.width - IndentX - rad1, IndentY, 1);
                }
            }
        }
        public static void Kapriz()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height * 0.15;
                    double rad2 = par1.width * 0.019;
                    double rad3 = par1.height * 0.06;
                    doc.ksArcByPoint(IndentX, IndentY, rad1, IndentX + rad1, IndentY, IndentX, IndentY + rad1, 1, 1);
                    doc.ksArcBy3Points(IndentX, IndentY + rad1, IndentX + rad2, par1.height / 2, IndentX,
                        par1.height - IndentY - rad1, 1);
                    doc.ksArcByPoint(IndentX, par1.height - IndentY, rad1, IndentX + rad1, par1.height - IndentY,
                        IndentX, par1.height - IndentY - rad1, -1, 1);
                    doc.ksArcBy3Points(IndentX + rad1, par1.height - IndentY, par1.width / 2,
                        par1.height - IndentY - rad3, par1.width - IndentX - rad1, par1.height - IndentY, 1);
                    doc.ksArcByPoint(par1.width - IndentX, par1.height - IndentY, rad1, par1.width - IndentX - rad1,
                        par1.height - IndentY, par1.width - IndentX, par1.height - IndentY - rad1, 1, 1);
                    doc.ksArcBy3Points(par1.width - IndentX, par1.height - IndentY - rad1, par1.width - IndentX - rad2,
                        par1.height / 2, par1.width - IndentX, IndentY + rad1, 1);
                    doc.ksArcByPoint(par1.width - IndentX, IndentY, rad1, par1.width - IndentX, IndentY + rad1,
                        par1.width - IndentX - rad1, IndentY, 1, 1);
                    doc.ksArcBy3Points(par1.width - IndentX - rad1, IndentY, par1.width / 2, IndentY + rad3,
                        IndentX + rad1, IndentY, 1);

                }
            }
        }
        public static void Venecia()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height * 0.15;
                    double rad2 = par1.width * 0.019;
                    doc.ksArcByPoint(IndentX, IndentY, rad1, IndentX + rad1, IndentY, IndentX, IndentY + rad1, 1, 1);
                    doc.ksArcBy3Points(IndentX, IndentY + rad1, IndentX + rad2, par1.height / 2, IndentX,
                        par1.height - IndentY-rad1, 1);
                    doc.ksArcByPoint(IndentX, par1.height - IndentY, rad1, IndentX + rad1, par1.height - IndentY,
                        IndentX, par1.height - IndentY - rad1, -1, 1);
                    doc.ksLineSeg(IndentX + rad1, IndentY, par1.width - IndentX - rad1, IndentY, 1);
                    doc.ksLineSeg(IndentX + rad1, par1.height - IndentY, par1.width - IndentX - rad1,
                        par1.height - IndentY, 1);
                    doc.ksArcByPoint(par1.width - IndentX, par1.height - IndentY, rad1, par1.width - IndentX - rad1,
                        par1.height - IndentY, par1.width - IndentX, par1.height - IndentY - rad1, 1, 1);
                    doc.ksArcBy3Points(par1.width - IndentX, par1.height - IndentY - rad1, par1.width - IndentX - rad2,
                        par1.height / 2, par1.width - IndentX, IndentY + rad1, 1);
                    doc.ksArcByPoint(par1.width - IndentX, IndentY, rad1, par1.width - IndentX, IndentY + rad1,
                        par1.width - IndentX - rad1, IndentY,1,1);
                }
            }
        }
        public static void KievskayaDv()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    int rad1 = 30;
                    double rad2 = par1.height / 15;
                    doc.ksArcByPoint(IndentX + rad2+15.8, IndentY+1.99, 32.16, IndentX + 47.91 + rad2, IndentY, IndentX + rad2,
                        IndentY + rad1, 1, 1);
                    doc.ksArcBy3Points(IndentX + rad2, IndentY + rad1, IndentX, par1.height / 2, IndentX + rad2,
                        par1.height - IndentY - rad1, 1);
                    doc.ksArcByPoint(IndentX + rad2+15.8, par1.height - IndentY-1.99, 32.16, IndentX + rad2 + 47.91,
                        par1.height - IndentY, IndentX + rad2, par1.height - IndentY - rad1, -1, 1);
                    doc.ksLineSeg(IndentX + rad2 + 47.91, par1.height - IndentY, par1.width - IndentX - rad2 - 47.91,
                        par1.height - IndentY, 1);
                    doc.ksArcByPoint(par1.width - IndentX - rad2-15.8, par1.height - IndentY-1.99, 32.16,
                        par1.width - IndentX - 47.91 - rad2, par1.height - IndentY, par1.width - IndentX - rad2,
                        par1.height - rad1 - IndentY, 1, 1);
                    doc.ksArcBy3Points(par1.width - IndentX - rad2, par1.height - IndentY - rad1, par1.width - IndentX,
                        par1.height / 2, par1.width - IndentX - rad2, IndentY + rad1, 1);
                    doc.ksArcByPoint(par1.width - IndentX - rad2-15.8, IndentY+1.99, 32.16, par1.width - IndentX - rad2,
                        IndentY + rad1, par1.width - IndentX - rad2 - 47.91, IndentY, 1, 1);
                    doc.ksLineSeg(par1.width - IndentX - rad2 - 47.91, IndentY, IndentX + rad2 + 47.91, IndentY, 1);
                }
            }
        }
        public static void Kvadro()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(20, 20, IndentX + 1 + 12.73, IndentY+1, 1);
                    doc.ksLineSeg(20, 20, IndentX + 1, IndentY + 1 + 12.73, 1);
                    doc.ksLineSeg(IndentX + 1, IndentY + 1 + 12.73, IndentX + 1, par1.height - IndentY - 1 - 12.73, 1);
                    doc.ksLineSeg(20, par1.height - 20, IndentX + 1, par1.height - IndentY - 1 - 12.73, 1);
                    doc.ksLineSeg(20, par1.height - 20, IndentX + 1 + 12.73, par1.height - IndentY - 1, 1);
                    doc.ksLineSeg(IndentX + 1 + 12.73, par1.height - IndentY - 1, par1.width - IndentX - 1 - 12.73,
                        par1.height - IndentY - 1, 1);
                    doc.ksLineSeg(par1.width - 20, par1.height - 20, par1.width - IndentX - 1 - 12.73,
                        par1.height - IndentY - 1, 1);
                    doc.ksLineSeg(par1.width - 20, par1.height - 20, par1.width - IndentX - 1,
                        par1.height - IndentY - 1 - 12.73, 1);
                    doc.ksLineSeg(par1.width - IndentX - 1, par1.height - IndentY - 1 - 12.73, par1.width - IndentX - 1,
                        IndentY + 1 + 12.73, 1);
                    doc.ksLineSeg(par1.width - 20, 20, par1.width - IndentX - 1, IndentY + 1 + 12.73, 1);
                    doc.ksLineSeg(par1.width - 20, 20, par1.width - IndentX - 1 - 12.73, IndentY + 1, 1);
                    doc.ksLineSeg(par1.width - IndentX - 1 - 12.73, IndentY + 1, IndentX + 1 + 12.73, IndentY + 1, 1);
                    //внутренний контур
                    doc.ksLineSeg(IndentX + 19, IndentY + 19, IndentX + 19, par1.height - IndentY - 19, 1);
                    doc.ksLineSeg(IndentX + 19, par1.height - IndentY - 19, par1.width - IndentX - 19,
                        par1.height - IndentY - 19, 1);
                    doc.ksLineSeg(par1.width - IndentX - 19, par1.height - IndentY - 19, par1.width - IndentX - 19,
                        IndentY + 19, 1);
                    doc.ksLineSeg(par1.width - IndentX - 19, IndentY + 19, IndentX + 19, IndentY + 19, 1);
                }
            }
        }//20 статичные края, если нужно чтобы изменялась вместе с отступами заменить на IndentX/Y-41
        public static void KlassikaDv()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - IndentY;
                    reference auxcircle1 = doc.ksCircle(par1.width - IndentX - rad1, par1.height / 2, rad1, 6);
                    reference auxlinexcyc1 = doc.ksLine(par1.width - IndentX - rad1, par1.height / 2, 30);
                    reference auxlinexcyc2 = doc.ksLine(par1.width - IndentX - rad1, par1.height / 2, -30);
                    reference auxline1 = doc.ksLine(0, par1.height - IndentY - rad1 / 2, 180);//линии 140-радиус конечные точки дуг
                    reference auxline2 = doc.ksLine(0, IndentY + rad1 / 2, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - IndentY, 180);//крайние линии
                    reference auxline4 = doc.ksLine(0, IndentY, 180);
                    mat.ksIntersectCirLin(par1.width - IndentX - rad1, par1.height / 2, rad1, 0, par1.height - IndentY - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - IndentX - rad1, par1.height / 2, rad1, 0, IndentY + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectLinLin(par1.width - IndentX - rad1, par1.height / 2, 30, 0, par1.height - IndentY, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - IndentX - rad1, par1.height / 2, -30, 0, IndentY, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 6);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 6);
                    reference auxlineS1 = doc.ksLineSeg(par1.width / 2, par1.height - IndentY, par1.width,
                        par1.height - IndentY, 6);
                    reference auxlineS2 = doc.ksLineSeg(par1.width / 2, IndentY, par1.width, IndentY, 6);
                    mat.ksIntersectLinSCir(par1.width / 2, par1.height - IndentY, par1.width,
                        par1.height - IndentY, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectLinSCir(par1.width / 2, IndentY, par1.width, IndentY, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(par1.width - IndentX - rad1, par1.height / 2, rad1, px1, py1, px2, py2, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px1, py1, px3, py3, -1, 1);
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px2, py2, px4, py4, 1, 1);
                    doc.ksLineSeg(par1.width/2, IndentY, px4, py4, 1);
                    doc.ksLineSeg(par1.width/2, par1.height - IndentY, px3, py3, 1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpCurve, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 - 1,
                        "1");

                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle1);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);
                }
            }
        }
        public static void KlassikaOd()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - IndentY;
                    reference auxcircle1 = doc.ksCircle(par1.width - IndentX - rad1, par1.height / 2, rad1, 6);
                    reference auxlinexcyc1 = doc.ksLine(par1.width - IndentX - rad1, par1.height / 2, 30);
                    reference auxlinexcyc2 = doc.ksLine(par1.width - IndentX - rad1, par1.height / 2, -30);
                    reference auxline1 = doc.ksLine(0, par1.height - IndentY - rad1 / 2, 180);//линии 140-радиус конечные точки дуг
                    reference auxline2 = doc.ksLine(0, IndentY + rad1 / 2, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - IndentY, 180);//крайние линии
                    reference auxline4 = doc.ksLine(0, IndentY, 180);
                    mat.ksIntersectCirLin(par1.width - IndentX - rad1, par1.height / 2, rad1, 0, par1.height - IndentY - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - IndentX - rad1, par1.height / 2, rad1, 0, IndentY + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectLinLin(par1.width - IndentX - rad1, par1.height / 2, 30, 0, par1.height - IndentY, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - IndentX - rad1, par1.height / 2, -30, 0, IndentY, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 6);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 6);
                    reference auxlineS1 = doc.ksLineSeg(par1.width/2, par1.height - IndentY, par1.width,
                        par1.height - IndentY, 6);
                    reference auxlineS2 = doc.ksLineSeg(par1.width / 2, IndentY, par1.width, IndentY, 6);
                    mat.ksIntersectLinSCir(par1.width / 2, par1.height - IndentY, par1.width,
                        par1.height - IndentY, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectLinSCir(par1.width / 2, IndentY, par1.width, IndentY, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(par1.width - IndentX - rad1, par1.height / 2, rad1, px1, py1, px2, py2, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px1, py1, px3, py3, -1, 1);
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px2, py2, px4, py4, 1, 1);
                    doc.ksEndGroup();

                    doc.ksLineSeg(IndentX, IndentY, px4, py4, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY, px3, py3, 1);
                    doc.ksLineSeg(IndentX, IndentY, IndentX, par1.height - IndentY, 1);

                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle1);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);
                }
            }
        }
        public static void ZigzagLeft()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksLineSeg(IndentX + 35, IndentY + 50, IndentX + 35, IndentY, 1);
                    doc.ksLineSeg(IndentX + 35, IndentY, par1.width - IndentX, IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX, IndentY, par1.width - IndentX, par1.height - IndentY - 35, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height - IndentY - 35, par1.width - IndentX - 50,
                        par1.height - IndentY - 35, 1);
                    doc.ksLineSeg(par1.width - IndentX - 35, par1.height - IndentY - 50, par1.width - IndentX - 35,
                        par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX - 35, par1.height - IndentY, IndentX, par1.height - IndentY, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY, IndentX, IndentY + 35, 1);
                    doc.ksLineSeg(IndentX, IndentY + 35, IndentX + 50, IndentY + 35, 1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpCurve, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 + 1,
                        "0");
                }
            }
        }
        public static void ZigzagRight()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(IndentX + 35, IndentY + 50, IndentX + 35, IndentY, 1);
                    doc.ksLineSeg(IndentX + 35, IndentY, par1.width - IndentX, IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX, IndentY, par1.width - IndentX, par1.height - IndentY - 35, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height - IndentY - 35, par1.width - IndentX - 50,
                        par1.height - IndentY - 35, 1);
                    doc.ksLineSeg(par1.width - IndentX - 35, par1.height - IndentY - 50, par1.width - IndentX - 35,
                        par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX - 35, par1.height - IndentY, IndentX, par1.height - IndentY, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY, IndentX, IndentY + 35, 1);
                    doc.ksLineSeg(IndentX, IndentY + 35, IndentX + 50, IndentY + 35, 1);
                }
            }
        }
        public static void Zmeika()
        {
        }
        public static void DuetLeft()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(0, IndentY - 20, par1.width, IndentY - 20, 1);
                    doc.ksLineSeg(0, IndentY + 5, par1.width, IndentY + 5, 1);
                    doc.ksLineSeg(par1.width - IndentX + 20, 0, par1.width - IndentY + 20, par1.height, 1);
                    doc.ksLineSeg(par1.width - IndentX - 5, 0, par1.width - IndentX - 5, par1.height, 1);

                }
            }
        }
        public static void DuetRight()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(0, IndentY - 20, par1.width, IndentY - 20, 1);
                    doc.ksLineSeg(0, IndentY + 5, par1.width, IndentY + 5, 1);
                    doc.ksLineSeg(IndentX - 20, 0, IndentX - 20, par1.height, 1);
                    doc.ksLineSeg(IndentX + 5, 0, IndentX + 5, par1.height, 1);
                }
            }
        }
        public static void KvadratDv()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    //первый квадрат
                    doc.ksLineSeg(IndentX, IndentY, IndentX, par1.height / 2 + (par1.height / 2 - IndentY)/4, 1);
                    doc.ksLineSeg(IndentX, par1.height / 2 + (par1.height / 2 - IndentY)/4, par1.width / 2 + (par1.width / 2 - IndentX) / 4,
                        par1.height / 2 + (par1.height / 2 - IndentY)/4, 1);
                    doc.ksLineSeg(par1.width / 2 + (par1.width / 2 - IndentX) / 4,par1.height / 2 + (par1.height / 2 - IndentY)/4,
                        par1.width / 2 + (par1.width / 2 - IndentX) / 4, IndentY, 1);
                    doc.ksLineSeg(IndentX, IndentY, par1.width / 2 + (par1.width / 2 - IndentX) / 4, IndentY, 1);
                    //второй квадрат
                    doc.ksLineSeg(par1.width / 2 - (par1.width / 2 - IndentX) / 4, par1.height / 2 - (par1.height / 2 - IndentY)/4,
                        par1.width / 2 - (par1.width / 2 - IndentX) / 4, par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width / 2 - (par1.width / 2 - IndentX) / 4, par1.height - IndentY, par1.width - IndentX,
                        par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height - IndentY, par1.width - IndentX,
                        par1.height / 2 - (par1.height / 2 - IndentY)/4, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height / 2 - (par1.height / 2 - IndentY)/4, par1.width / 2 - (par1.width / 2 - IndentX) / 4,
                        par1.height / 2 - (par1.height / 2 - IndentY)/4, 1);
                }
            }
        }
        public static void Kletka()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(0, IndentY, par1.width, IndentY, 1);
                    doc.ksLineSeg(IndentX, 0, IndentX, par1.height, 1);
                    doc.ksLineSeg(0, par1.height - IndentY, par1.width, par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width-IndentX,par1.height,par1.width-IndentX,0,1);
                }
            }
        }
        public static void Lzheviborka()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(0, IndentY, par1.width, IndentY, 1);
                    doc.ksLineSeg(IndentX, IndentY, IndentX, par1.height - IndentY, 1);
                    doc.ksLineSeg(0, par1.height - IndentY, par1.width, par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height - IndentY, par1.width - IndentX, IndentY, 1);
                }
            }
        }
        public static void PolosiBokovie()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(IndentX - 25, IndentY - 25, par1.width - IndentX + 25, IndentY - 25, 1);
                    doc.ksLineSeg(IndentX + 5, IndentY + 5, par1.width - IndentX - 5, IndentY + 5, 1);
                }
            }
        }
        public static void PolosiDv()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(0, IndentY, par1.width, IndentY, 1);
                    doc.ksLineSeg(0, IndentY + 25, par1.width, IndentY + 25, 1);
                    doc.ksLineSeg(0, par1.height - IndentY, par1.width, par1.height - IndentY, 1);
                    doc.ksLineSeg(0, par1.height - IndentY - 25, par1.width, par1.height-IndentY-25, 1);
                }
            }
        }
        public static void Riv_era()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(IndentX + IndentX / 2, IndentY, IndentX + IndentX / 2, IndentY * 2, 1);
                    doc.ksLineSeg(IndentX + IndentX / 2, IndentY * 2, IndentX * 2, IndentY * 2, 1);
                    doc.ksLineSeg(IndentX * 2, IndentY * 2, IndentX * 2, IndentY + IndentY / 2, 1);
                    doc.ksLineSeg(IndentX * 2, IndentY + IndentY / 2, IndentX, IndentY + IndentY / 2, 1);
                    doc.ksLineSeg(IndentX, IndentY + IndentY / 2, IndentX, par1.height - IndentY - IndentY / 2, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY - IndentY / 2, IndentX * 2,
                        par1.height - IndentY - IndentY / 2, 1);
                    doc.ksLineSeg(IndentX * 2, par1.height - IndentY - IndentY / 2, IndentX * 2,
                        par1.height - IndentY * 2, 1);
                    doc.ksLineSeg(IndentX * 2, par1.height - IndentY * 2, IndentX + IndentX / 2,
                        par1.height - IndentY * 2, 1);
                    doc.ksLineSeg(IndentX + IndentX / 2, par1.height - IndentY * 2, IndentX + IndentX / 2,
                        par1.height - IndentY, 1);
                    doc.ksLineSeg(IndentX + IndentX / 2, par1.height - IndentY, par1.width - IndentX - IndentX / 2,
                        par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX - IndentX / 2, par1.height - IndentY,
                        par1.width - IndentX - IndentX / 2, par1.height - IndentY * 2, 1);
                    doc.ksLineSeg(par1.width - IndentX - IndentX / 2, par1.height - IndentY * 2,
                        par1.width - IndentX * 2, par1.height - IndentY * 2, 1);
                    doc.ksLineSeg(par1.width - IndentX * 2, par1.height - IndentY * 2, par1.width - IndentX * 2,
                        par1.height - IndentY - IndentY / 2, 1);
                    doc.ksLineSeg(par1.width - IndentX * 2, par1.height - IndentY - IndentY / 2, par1.width - IndentX,
                        par1.height - IndentY - IndentY / 2, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height - IndentY - IndentY / 2, par1.width - IndentX,
                        IndentY + IndentY / 2, 1);
                    doc.ksLineSeg(par1.width - IndentX, IndentY + IndentY / 2, par1.width - IndentX * 2,
                        IndentY + IndentY / 2, 1);
                    doc.ksLineSeg(par1.width - IndentX * 2, IndentY + IndentY / 2, par1.width - IndentX * 2,
                        IndentY * 2, 1);
                    doc.ksLineSeg(par1.width - IndentX * 2, IndentY * 2, par1.width - IndentX - IndentX / 2,
                        IndentY * 2, 1);
                    doc.ksLineSeg(par1.width - IndentX - IndentX / 2, IndentY * 2, par1.width - IndentX - IndentX / 2,
                        IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX - IndentX / 2, IndentY, IndentX + IndentX / 2, IndentY, 1);
                }
            }
        }
        public static void StrelaLeft()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    //внешний контур
                    doc.ksLineSeg(IndentX - 13, par1.height - IndentY, par1.width / 2+30, par1.height-IndentY, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY + 13, IndentX, par1.height / 2-30, 1);
                    //внутренний контур
                    doc.ksLineSeg(IndentX + 17, par1.height - IndentY - 30, par1.width / 2,
                        par1.height - IndentY - 30, 1);
                    doc.ksLineSeg(IndentX + 30, par1.height - IndentY - 17, IndentX + 30, par1.height / 2 , 1);
                }
            }
        }
        public static void StrelaRight()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    reference grpLine = doc.ksNewGroup(0);
                    //внешний контур
                    doc.ksLineSeg(IndentX - 13, par1.height - IndentY, par1.width / 2 + 30, par1.height - IndentY, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY + 13, IndentX, par1.height / 2 - 30, 1);
                    //внутренний контур
                    doc.ksLineSeg(IndentX + 17, par1.height - IndentY - 30, par1.width / 2,
                        par1.height - IndentY - 30, 1);
                    doc.ksLineSeg(IndentX + 30, par1.height - IndentY - 17, IndentX + 30, par1.height / 2, 1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpLine, par1.width/2, par1.height / 2, par1.width/2+1, par1.height / 2 , "0");
                }
            }
        }
        public static void StrelaDvLeft()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    reference grpLine = doc.ksNewGroup(0);
                    //внешний контур
                    doc.ksLineSeg(IndentX - 13, par1.height - IndentY, par1.width / 2 + 30, par1.height - IndentY, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY + 13, IndentX, par1.height / 2 - 30, 1);
                    //внутренний контур
                    doc.ksLineSeg(IndentX + 17, par1.height - IndentY - 30, par1.width / 2,
                        par1.height - IndentY - 30, 1);
                    doc.ksLineSeg(IndentX + 30, par1.height - IndentY - 17, IndentX + 30, par1.height / 2, 1);
                    doc.ksEndGroup();
                    reference symmobj = doc.ksSymmetryObj(grpLine, par1.width / 2, par1.height / 2, par1.width / 2 + 1, par1.height / 2, "1");
                    doc.ksSymmetryObj(symmobj, par1.width / 2, par1.height / 2, par1.width / 2 , par1.height / 2+1,
                        "0");
                }
            }
        }
        public static void StrelaDvRight()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    reference grpLine = doc.ksNewGroup(0);
                    //внешний контур
                    doc.ksLineSeg(IndentX - 13, par1.height - IndentY, par1.width / 2 + 30, par1.height - IndentY, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY + 13, IndentX, par1.height / 2 - 30, 1);
                    //внутренний контур
                    doc.ksLineSeg(IndentX + 17, par1.height - IndentY - 30, par1.width / 2,
                        par1.height - IndentY - 30, 1);
                    doc.ksLineSeg(IndentX + 30, par1.height - IndentY - 17, IndentX + 30, par1.height / 2, 1);
                    doc.ksEndGroup();
                    reference symmobj = doc.ksSymmetryObj(grpLine, par1.width / 2, par1.height / 2, par1.width / 2 + 1, par1.height / 2, "0");
                    reference symmobj2 = doc.ksSymmetryObj(symmobj, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 + 1,
                        "1");
                    doc.ksSymmetryObj(symmobj2, par1.width / 2, par1.height / 2, par1.width / 2 - 1, par1.height / 2,
                        "0");
                }
            }
        }
        public static void Tehno()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(par1.width / 3, 0, par1.width / 3, par1.height, 1);
                    doc.ksLineSeg((par1.width / 3) * 2, 0, (par1.width / 3) * 2, par1.height, 1);
                }
            }
        }
        public static void TrioLeft()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    reference grpLine = doc.ksNewGroup(0);
                    doc.ksLineSeg(IndentX - 20, 0, IndentX - 20, par1.height, 1);
                    doc.ksLineSeg(IndentX + 5, 0, IndentX + 5, par1.height, 1);
                    doc.ksLineSeg(IndentX + 30, 0, IndentX + 30, par1.height, 1);
                    doc.ksLineSeg(0, IndentY - 20, par1.width, IndentY - 20, 1);
                    doc.ksLineSeg(0, IndentY + 5, par1.width, IndentY + 5, 1);
                    doc.ksLineSeg(0, IndentY + 30, par1.width, IndentY + 30, 1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpLine, par1.width / 2, par1.height / 2, par1.width / 2 + 1, par1.height / 2,
                        "0");

                }
            }
        }
        public static void TrioRight()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(IndentX - 20, 0, IndentX - 20, par1.height, 1);
                    doc.ksLineSeg(IndentX + 5, 0, IndentX + 5, par1.height, 1);
                    doc.ksLineSeg(IndentX + 30, 0, IndentX + 30, par1.height, 1);
                    doc.ksLineSeg(0, IndentY - 20, par1.width, IndentY - 20, 1);
                    doc.ksLineSeg(0, IndentY + 5, par1.width, IndentY + 5, 1);
                    doc.ksLineSeg(0, IndentY + 30, par1.width, IndentY + 30, 1);
                }
            }
        }
        public static void Universal()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(0, IndentY, par1.width - IndentX, IndentY, 1);
                    doc.ksLineSeg(IndentX, IndentY, IndentX, par1.height, 1);
                    doc.ksLineSeg(IndentX, par1.height - IndentY, par1.width, par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height - IndentY, par1.width - IndentX, 0, 1);
                }
            }
        }
        public static void TehnoKrupnii()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);

                    model1.x = IndentX-40;
                    model1.y = IndentY-40;
                    model1.height = par1.height - IndentY*2+80;
                    model1.width = par1.width - IndentX*2+80;
                    model1.style = 1;
                    doc.ksRectangle(model1);

                    model2.x = IndentX + 16-40;
                    model2.y = IndentY + 16-40;
                    model2.height = par1.height - IndentY * 2 - 32+80;
                    model2.width = par1.width - IndentX * 2 - 32+80;
                    model2.style = 1;
                    doc.ksRectangle(model2);

                    model3.x = IndentX + 32-40;
                    model3.y = IndentY + 32-40;
                    model3.height = par1.height - IndentY * 2 - 64+80;
                    model3.width = par1.width - IndentX * 2 - 64+80;
                    model3.style = 1;
                    doc.ksRectangle(model3);

                    model4.x = IndentX + 48-40;
                    model4.y = IndentY + 48-40;
                    model4.height = par1.height - IndentY * 2 - 96+80;
                    model4.width = par1.width - IndentX * 2 - 96+80;
                    model4.style = 1;
                    doc.ksRectangle(model4);

                    model5.x = IndentX + 64-40;
                    model5.y = IndentY + 64-40;
                    model5.height = par1.height - IndentY * 2 - 128+80;
                    model5.width = par1.width - IndentX * 2 - 128+80;
                    model5.style = 1;
                    doc.ksRectangle(model5);

                    model6.x = IndentX + 80-40;
                    model6.y = IndentY + 80-40;
                    model6.height = par1.height - IndentY * 2 - 160+80;
                    model6.width = par1.width - IndentX * 2 - 160+80;
                    model6.style = 1;
                    doc.ksRectangle(model6);

                }
            }
        }
        public static void TehnoMelkii()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);

                    model1.x = IndentX - 40;
                    model1.y = IndentY - 40;
                    model1.height = par1.height - IndentY * 2 + 80;
                    model1.width = par1.width - IndentX * 2 + 80;
                    model1.style = 1;
                    doc.ksRectangle(model1);

                    model2.x = IndentX + 12 - 40;
                    model2.y = IndentY + 12 - 40;
                    model2.height = par1.height - IndentY * 2 - 24 + 80;
                    model2.width = par1.width - IndentX * 2 - 24 + 80;
                    model2.style = 1;
                    doc.ksRectangle(model2);

                    model3.x = IndentX + 24 - 40;
                    model3.y = IndentY + 24 - 40;
                    model3.height = par1.height - IndentY * 2 - 48 + 80;
                    model3.width = par1.width - IndentX * 2 - 48 + 80;
                    model3.style = 1;
                    doc.ksRectangle(model3);

                    model4.x = IndentX + 36 - 40;
                    model4.y = IndentY + 36 - 40;
                    model4.height = par1.height - IndentY * 2 - 72 + 80;
                    model4.width = par1.width - IndentX * 2 - 72 + 80;
                    model4.style = 1;
                    doc.ksRectangle(model4);

                    model5.x = IndentX + 48 - 40;
                    model5.y = IndentY + 48 - 40;
                    model5.height = par1.height - IndentY * 2 - 96 + 80;
                    model5.width = par1.width - IndentX * 2 - 96 + 80;
                    model5.style = 1;
                    doc.ksRectangle(model5);

                    model6.x = IndentX + 60 - 40;
                    model6.y = IndentY + 60 - 40;
                    model6.height = par1.height - IndentY * 2 - 120 + 80;
                    model6.width = par1.width - IndentX * 2 - 120 + 80;
                    model6.style = 1;
                    doc.ksRectangle(model6);

                    model7.x = IndentX + 72 - 40;
                    model7.y = IndentY + 72 - 40;
                    model7.height = par1.height - IndentY * 2 - 144 + 80;
                    model7.width = par1.width - IndentX * 2 - 144 + 80;
                    model7.style = 1;
                    doc.ksRectangle(model7);

                    model8.x = IndentX + 84 - 40;
                    model8.y = IndentY + 84 - 40;
                    model8.height = par1.height - IndentY * 2 - 168 + 80;
                    model8.width = par1.width - IndentX * 2 - 168 + 80;
                    model8.style = 1;
                    doc.ksRectangle(model8);
                }
            }
        }
        public static void Elegant1()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksNurbsPointParam parN = (ksNurbsPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_NurbsPointParam);
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - IndentY-15;
                    reference auxcircle1 = doc.ksCircle(par1.width - IndentX-15 - rad1, par1.height / 2, rad1, 6);
                    reference auxlinexcyc1 = doc.ksLine(par1.width - IndentX-15 - rad1, par1.height / 2, 30);
                    reference auxlinexcyc2 = doc.ksLine(par1.width - IndentX-15 - rad1, par1.height / 2, -30);
                    reference auxline1 = doc.ksLine(0, par1.height - IndentY-15 - rad1 / 2, 180);//линии 140-радиус конечные точки дуг
                    reference auxline2 = doc.ksLine(0, IndentY+15 + rad1 / 2, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - IndentY-15, 180);//крайние линии
                    reference auxline4 = doc.ksLine(0, IndentY+15, 180);
                    mat.ksIntersectCirLin(par1.width - IndentX-15 - rad1, par1.height / 2, rad1, 0, par1.height - IndentY-15 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - IndentX-15 - rad1, par1.height / 2, rad1, 0, IndentY+15 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectLinLin(par1.width - IndentX-15 - rad1, par1.height / 2, 30, 0, par1.height - IndentY-15, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - IndentX-15 - rad1, par1.height / 2, -30, 0, IndentY+15, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 6);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 6);
                    reference auxlineS1 = doc.ksLineSeg(par1.width / 2, par1.height - IndentY-15, par1.width,
                        par1.height - IndentY-15, 6);
                    reference auxlineS2 = doc.ksLineSeg(par1.width / 2, IndentY+15, par1.width, IndentY+15, 6);
                    mat.ksIntersectLinSCir(par1.width / 2, par1.height - IndentY-15, par1.width,
                        par1.height - IndentY-15, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectLinSCir(par1.width / 2, IndentY+15, par1.width, IndentY+15, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(par1.width - IndentX-15 - rad1, par1.height / 2, rad1, px1, py1, px2, py2, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px1, py1, px3, py3, -1, 1);
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px2, py2, px4, py4, 1, 1);

                    #region кв52х52
                    doc.ksArcByPoint(par1.width - IndentX - 15 - rad1, par1.height / 2, rad1+23, px1, py1, px2, py2, -1, 7);
                    doc.ksArcByPoint(pxc1, pyc1, rad1-23, px1, py1, px3, py3, -1, 7);
                    doc.ksArcByPoint(pxc2, pyc2, rad1-23, px2, py2, px4, py4, 1, 7);
                    doc.ksLineSeg(px4 + 23, IndentY - 8, px4 + 23, py4, 7);
                    doc.ksLineSeg(px4 + 23, IndentY - 8, par1.width / 2, IndentY - 8, 7);
                    doc.ksLineSeg(px3 + 23, par1.height - IndentY + 8, px3 + 23, py3, 7);
                    doc.ksLineSeg(px3 + 23, par1.height - IndentY + 8, par1.width / 2, par1.height - IndentY + 8, 7);
                    #endregion

                    #region кв100х100
                    doc.ksArcByPoint(par1.width - IndentX - 15 - rad1, par1.height / 2, rad1 - 25, px1, py1, px2, py2, -1, 7);
                    reference cur1002 = doc.ksArcByPoint(pxc1, pyc1, rad1 + 25, px1, py1, px3, py3, -1, 7);
                    reference cur1001 = doc.ksArcByPoint(pxc2, pyc2, rad1 + 25, px2, py2, px4, py4, 1, 7);
                    reference curL1 = doc.ksLineSeg(par1.width / 2, IndentY + 15 + 25, px4, IndentY + 15 + 25, 6);
                    reference curL2 = doc.ksLineSeg(par1.width / 2, par1.height - IndentY - 15 - 25, px3,
                        par1.height - IndentY - 15 - 25, 6);
                    mat.ksIntersectCurvCurv(curL1, cur1001, arr);
                    GetPoint(arr, par);
                    double px1001 = par.x;
                    double py1001 = par.y;
                    doc.ksTrimmCurve(cur1001, px2, py2, px1001, py1001, px1001, py1001, 1);
                    mat.ksIntersectCurvCurv(curL2, cur1002, arr);
                    GetPoint(arr, par);
                    double px1002 = par.x;
                    double py1002 = par.y;
                    doc.ksTrimmCurve(cur1002, px1, py1, px1002, py1002, px1002, py1002, 1);
                    doc.ksLineSeg(par1.width / 2, IndentY + 15 + 25, px1001, py1001, 7);
                    doc.ksLineSeg(par1.width / 2, par1.height - IndentY - 15 - 25, px1002, py1002, 7);
                    doc.ksDeleteObj(curL1);
                    doc.ksDeleteObj(curL2);
                    #endregion

                    doc.ksLineSeg(par1.width / 2, IndentY+15, px4, py4, 1);
                    doc.ksLineSeg(par1.width / 2, par1.height - IndentY-15, px3, py3, 1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpCurve, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 - 1,
                        "1");
                    
                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle1);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);

                    #region VENZEL
                    doc.ksBezier(0, 2);
                    doc.ksPoint(par1.width / 2 - 111.1, par1.height / 2, 7);
                    doc.ksPoint(par1.width / 2 - 89.5, par1.height / 2 + 2.9, 7);
                    doc.ksPoint(par1.width / 2 - 67, par1.height / 2 + 5.8, 7);
                    reference blockbez1 = doc.ksEndObj();

                    doc.ksBezier(0, 2);
                    doc.ksPoint(par1.width / 2 - 67, par1.height / 2 + 5.8, 7);
                    doc.ksPoint(par1.width / 2 - 64.83, par1.height / 2 - 0.86, 7);
                    doc.ksPoint(par1.width / 2 - 62.36, par1.height / 2 - 4.75, 7);
                    doc.ksPoint(par1.width / 2 - 58.05, par1.height / 2 - 8.88, 7);
                    doc.ksPoint(par1.width / 2 - 50.73, par1.height / 2 - 12.26, 7);
                    doc.ksPoint(par1.width / 2 - 40.75, par1.height / 2 - 13.69, 7);
                    doc.ksPoint(par1.width / 2 - 31.18, par1.height / 2 - 12.26, 7);
                    doc.ksPoint(par1.width / 2 - 22.88, par1.height / 2 - 7.66, 7);
                    doc.ksPoint(par1.width / 2 - 14.96, par1.height / 2 - 1.04, 7);
                    doc.ksPoint(par1.width / 2 - 7.18, par1.height / 2 + 7.31, 7);
                    doc.ksPoint(par1.width / 2, par1.height / 2 + 17.4, 7);
                    reference blockbez2 = doc.ksEndObj();

                    doc.ksBezier(0, 2);
                    doc.ksPoint(par1.width / 2 - 50.73, par1.height / 2, 7);
                    doc.ksPoint(par1.width / 2 - 49.76, par1.height / 2 - 6.59, 7);
                    doc.ksPoint(par1.width / 2 - 43.37, par1.height / 2 - 15.41, 7);
                    doc.ksPoint(par1.width / 2 - 33.04, par1.height / 2 - 18.86, 7);
                    doc.ksPoint(par1.width / 2 - 21.09, par1.height / 2 - 16.05, 7);
                    doc.ksPoint(par1.width / 2 - 7.8, par1.height / 2 - 7.66, 7);
                    doc.ksPoint(par1.width / 2, par1.height / 2, 7);
                    reference blockbez3 = doc.ksEndObj();
                    reference grpVenzel = doc.ksNewGroup(0);
                    doc.ksSymmetryObj(blockbez1, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 - 1,
                        "1");
                    doc.ksSymmetryObj(blockbez2, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 - 1,
                        "1");
                    doc.ksSymmetryObj(blockbez3, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 - 1,
                        "1");
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(blockbez1, par1.width / 2, par1.height / 2, par1.width / 2-1, par1.height / 2,
                        "1");
                    doc.ksSymmetryObj(blockbez2, par1.width / 2, par1.height / 2, par1.width / 2-1, par1.height / 2,
                        "1");
                    doc.ksSymmetryObj(blockbez3, par1.width / 2, par1.height / 2, par1.width / 2-1, par1.height / 2,
                        "1");
                    doc.ksSymmetryObj(grpVenzel, par1.width / 2, par1.height / 2, par1.width / 2 + 1, par1.height / 2,
                        "1");

                    #endregion

                    #region Gravirovka
                    reference grpGrav = doc.ksNewGroup(0);
                    doc.ksNurbs(4, false, 2);
                    parN.x = 36.85;parN.y = 17.28;parN.weight = 1;doc.ksNurbsPoint(parN);
                    parN.x = 37.76;parN.y = 22.49;parN.weight = 1;doc.ksNurbsPoint(parN);
                    parN.x = 34.49;parN.y = 24.83;parN.weight = 1;doc.ksNurbsPoint(parN);
                    parN.x = 31.79;parN.y = 24.83;parN.weight = 1;doc.ksNurbsPoint(parN);
                    parN.x = 31.79;parN.y = 28.26;parN.weight = 1;doc.ksNurbsPoint(parN);
                    parN.x = 34.64;parN.y = 31.11;parN.weight = 1;doc.ksNurbsPoint(parN);
                    parN.x = 40.61; parN.y = 31.11; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 42.07; parN.y = 27.24; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 38.29; parN.y = 27.22; parN.weight = 1; doc.ksNurbsPoint(parN);
                    doc.ksEndObj();

                    doc.ksArcByAngle(37.5777, 43.5749, 16.3704, 272.493, 310.360, -1, 2);

                    doc.ksNurbs(4, false, 2);
                    parN.x = 45.57; parN.y = 32; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 55.41; parN.y = 28.5; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 65.23; parN.y = 27.31; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 66.41; parN.y = 30.17; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 56.07; parN.y = 36.31; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 45.87; parN.y = 37.27; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 35.6; parN.y = 35.14; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 23.61; parN.y = 33.21; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 15.48; parN.y = 37.96; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 11.83; parN.y = 48.78; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 17; parN.y = 61.33; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 24.58; parN.y = 73.66; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 27.13; parN.y = 84; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 25.61; parN.y = 92.13; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 22.99; parN.y = 95.99; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 18.92; parN.y = 94.55; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 18.92; parN.y = 80.97; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 17; parN.y = 77.04; parN.weight = 1; doc.ksNurbsPoint(parN);
                    doc.ksEndObj();

                    doc.ksNurbs(4, false, 2);
                    parN.x = 17; parN.y = 77.04; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 21.44; parN.y = 87.58; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 24.6; parN.y = 96.68; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 32.51; parN.y = 96.25; parN.weight = 1; doc.ksNurbsPoint(parN);
                    parN.x = 39.15; parN.y = 94.77; parN.weight = 1; doc.ksNurbsPoint(parN);
                    doc.ksEndObj();
                    //doc.ksLineSeg(45.57, 32, par1.width / 2, 32, 2);
                    //doc.ksLineSeg(17, 77.04, 17, par1.height / 2, 2);
                    doc.ksEndGroup();
                    reference symmCurveGrav = doc.ksSymmetryObj(grpGrav, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2-1, "1");// -B
                    reference symmCurveGrav2 = doc.ksSymmetryObj(grpGrav, par1.width / 2, par1.height / 2, par1.width / 2+1, par1.height / 2, "1");// |L
                    reference symmCurveGrav3 = doc.ksSymmetryObj(symmCurveGrav, par1.width / 2, par1.height / 2, par1.width / 2 + 1,// |R
                        par1.height / 2, "1");
                    doc.ksMoveObj(grpGrav, IndentX - 60, IndentY - 60);
                    doc.ksMoveObj(symmCurveGrav, -IndentX + 60, IndentY - 60);
                    doc.ksMoveObj(symmCurveGrav2, IndentX - 60, -IndentY + 60);
                    doc.ksMoveObj(symmCurveGrav3, -IndentX + 60, -IndentY + 60);
                    doc.ksLineSeg(IndentX - 60 + 45.57, IndentY - 60 + 32, par1.width - IndentX + 60 - 45.57,
                        IndentY - 60 + 32,2);
                    doc.ksLineSeg(IndentX - 60 + 17, IndentY - 60 + 77.04, IndentX - 60 + 17,
                        par1.height - IndentY + 60 - 77.04, 2);
                    doc.ksLineSeg(IndentX - 60 + 45.57, par1.height - IndentY + 60 - 32,
                        par1.width - IndentX + 60 - 45.57, par1.height - IndentY + 60 - 32, 2);
                    doc.ksLineSeg(par1.width - IndentX + 60 - 17, par1.height - IndentY + 60 - 77.04,
                        par1.width - IndentX + 60 - 17, IndentY - 60 + 77.04, 2);

                    #endregion
                }
            }
        }//Работа с безье и NURBS(сплайн) линиями
        public static void Elegant2()
        {
            doc = (ksDocument2D)kompas.Document2D();
            mat = (ksMathematic2D)kompas.GetMathematic2D();
            ksDynamicArray arr = (ksDynamicArray)kompas.GetDynamicArray(ldefin2d.POINT_ARR);
            ksMathPointParam par = (ksMathPointParam)kompas.GetParamStruct((short)StructType2DEnum.ko_MathPointParam);
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    double rad1 = par1.height / 2 - IndentY - 15;
                    reference auxcircle1 = doc.ksCircle(par1.width - IndentX - 15 - rad1, par1.height / 2, rad1, 6);
                    reference auxlinexcyc1 = doc.ksLine(par1.width - IndentX - 15 - rad1, par1.height / 2, 30);
                    reference auxlinexcyc2 = doc.ksLine(par1.width - IndentX - 15 - rad1, par1.height / 2, -30);
                    reference auxline1 = doc.ksLine(0, par1.height - IndentY - 15 - rad1 / 2, 180);//линии 140-радиус конечные точки дуг
                    reference auxline2 = doc.ksLine(0, IndentY + 15 + rad1 / 2, 180);
                    reference auxline3 = doc.ksLine(0, par1.height - IndentY - 15, 180);//крайние линии
                    reference auxline4 = doc.ksLine(0, IndentY + 15, 180);
                    mat.ksIntersectCirLin(par1.width - IndentX - 15 - rad1, par1.height / 2, rad1, 0, par1.height - IndentY - 15 - rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px1 = par.x;
                    double py1 = par.y;

                    mat.ksIntersectCirLin(par1.width - IndentX - 15 - rad1, par1.height / 2, rad1, 0, IndentY + 15 + rad1 / 2, 180, arr);
                    GetPoint(arr, par);
                    double px2 = par.x;
                    double py2 = par.y;

                    mat.ksIntersectLinLin(par1.width - IndentX - 15 - rad1, par1.height / 2, 30, 0, par1.height - IndentY - 15, 180, arr);
                    GetPoint(arr, par);
                    double pxc1 = par.x;//координаты цетра дуги верхней(левой)
                    double pyc1 = par.y;

                    mat.ksIntersectLinLin(par1.width - IndentX - 15 - rad1, par1.height / 2, -30, 0, IndentY + 15, 180, arr);
                    GetPoint(arr, par);
                    double pxc2 = par.x;//координаты цетра дуги нижней(правой)
                    double pyc2 = par.y;

                    reference auxcircle2 = doc.ksCircle(pxc1, pyc1, rad1, 6);//поиск крайней точки для верхней дуги
                    reference auxcircle3 = doc.ksCircle(pxc2, pyc2, rad1, 6);
                    reference auxlineS1 = doc.ksLineSeg(par1.width / 2, par1.height - IndentY - 15, par1.width,
                        par1.height - IndentY - 15, 6);
                    reference auxlineS2 = doc.ksLineSeg(par1.width / 2, IndentY + 15, par1.width, IndentY + 15, 6);
                    mat.ksIntersectLinSCir(par1.width / 2, par1.height - IndentY - 15, par1.width,
                        par1.height - IndentY - 15, pxc1, pyc1, rad1, arr);
                    GetPoint(arr, par);
                    double px3 = par.x;
                    double py3 = par.y;

                    mat.ksIntersectLinSCir(par1.width / 2, IndentY + 15, par1.width, IndentY + 15, pxc2, pyc2, rad1, arr);//поиск крайней точки для нижней дуги
                    GetPoint(arr, par);
                    double px4 = par.x;
                    double py4 = par.y;

                    reference grpCurve = doc.ksNewGroup(0);
                    doc.ksArcByPoint(par1.width - IndentX - 15 - rad1, par1.height / 2, rad1, px1, py1, px2, py2, -1, 1);
                    doc.ksArcByPoint(pxc1, pyc1, rad1, px1, py1, px3, py3, -1, 1);
                    doc.ksArcByPoint(pxc2, pyc2, rad1, px2, py2, px4, py4, 1, 1);

                    #region кв52х52
                    doc.ksArcByPoint(par1.width - IndentX - 15 - rad1, par1.height / 2, rad1 + 23, px1, py1, px2, py2, -1, 7);
                    doc.ksArcByPoint(pxc1, pyc1, rad1 - 23, px1, py1, px3, py3, -1, 7);
                    doc.ksArcByPoint(pxc2, pyc2, rad1 - 23, px2, py2, px4, py4, 1, 7);
                    doc.ksLineSeg(px4 + 23, IndentY - 8, px4 + 23, py4, 7);
                    doc.ksLineSeg(px4 + 23, IndentY - 8, par1.width / 2, IndentY - 8, 7);
                    doc.ksLineSeg(px3 + 23, par1.height - IndentY + 8, px3 + 23, py3, 7);
                    doc.ksLineSeg(px3 + 23, par1.height - IndentY + 8, par1.width / 2, par1.height - IndentY + 8, 7);
                    #endregion

                    #region кв100х100
                    doc.ksArcByPoint(par1.width - IndentX - 15 - rad1, par1.height / 2, rad1 - 25, px1, py1, px2, py2, -1, 7);
                    reference cur1002 = doc.ksArcByPoint(pxc1, pyc1, rad1 + 25, px1, py1, px3, py3, -1, 7);
                    reference cur1001 = doc.ksArcByPoint(pxc2, pyc2, rad1 + 25, px2, py2, px4, py4, 1, 7);
                    reference curL1 = doc.ksLineSeg(par1.width / 2, IndentY + 15 + 25, px4, IndentY + 15 + 25, 6);
                    reference curL2 = doc.ksLineSeg(par1.width / 2, par1.height - IndentY - 15 - 25, px3,
                        par1.height - IndentY - 15 - 25, 6);
                    mat.ksIntersectCurvCurv(curL1, cur1001, arr);
                    GetPoint(arr, par);
                    double px1001 = par.x;
                    double py1001 = par.y;
                    doc.ksTrimmCurve(cur1001, px2, py2, px1001, py1001, px1001, py1001, 1);
                    mat.ksIntersectCurvCurv(curL2, cur1002, arr);
                    GetPoint(arr, par);
                    double px1002 = par.x;
                    double py1002 = par.y;
                    doc.ksTrimmCurve(cur1002, px1, py1, px1002, py1002, px1002, py1002, 1);
                    doc.ksLineSeg(par1.width / 2, IndentY + 15 + 25, px1001, py1001, 7);
                    doc.ksLineSeg(par1.width / 2, par1.height - IndentY - 15 - 25, px1002, py1002, 7);
                    doc.ksDeleteObj(curL1);
                    doc.ksDeleteObj(curL2);
                    #endregion

                    doc.ksLineSeg(par1.width / 2, IndentY + 15, px4, py4, 1);
                    doc.ksLineSeg(par1.width / 2, par1.height - IndentY - 15, px3, py3, 1);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpCurve, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 - 1,
                        "1");

                    doc.ksDeleteObj(auxline1);//удаляем вспомогательные линии
                    doc.ksDeleteObj(auxline2);
                    doc.ksDeleteObj(auxline3);
                    doc.ksDeleteObj(auxline4);
                    doc.ksDeleteObj(auxlinexcyc1);
                    doc.ksDeleteObj(auxlinexcyc2);
                    doc.ksDeleteObj(auxcircle1);
                    doc.ksDeleteObj(auxcircle2);
                    doc.ksDeleteObj(auxcircle3);
                    doc.ksDeleteObj(auxlineS1);
                    doc.ksDeleteObj(auxlineS2);

                    #region Venzel

                    doc.ksCircle(par1.width / 2 - 46.74, par1.height / 2, 3.0696, 2);
                    doc.ksCircle(par1.width / 2 + 46.74, par1.height / 2, 3.0696, 2);

                    reference grpVenzOSMirrorY = doc.ksNewGroup(0);                    
                    doc.ksArcBy3Points(par1.width / 2 - 111.62, par1.height / 2 + 0.51, par1.width / 2 - 111.89,
                        par1.height / 2, par1.width / 2 - 111.62, par1.height / 2 - 0.51, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 92.13, par1.height / 2 - 0.51, par1.width/2 - 91.86,
                        par1.height / 2, par1.width / 2 - 92.13, par1.height / 2 + 0.51, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 81.34, par1.height / 2 + 0.87, par1.width / 2 - 82.08,
                        par1.height / 2, par1.width / 2 - 81.34, par1.height / 2 - 0.87, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 54.36, par1.height / 2 + 0.83, par1.width / 2 - 55.07,
                        par1.height / 2, par1.width / 2 - 54.36, par1.height / 2 - 0.83, 2);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpVenzOSMirrorY, par1.width / 2, par1.height / 2, par1.width / 2,
                        par1.height / 2 - 1, "1");

                    reference grpVenzOSMirrorX = doc.ksNewGroup(0);
                    doc.ksArcBy3Points(par1.width / 2 - 15.7722, par1.height / 2 + 13.9320, par1.width / 2,
                        par1.height / 2 + 4.64, par1.width / 2 + 15.7722, par1.height / 2 + 13.9320, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 36.8796, par1.height / 2 + 16.9503, par1.width / 2,
                        par1.height / 2 + 1.74, par1.width / 2 + 36.8796, par1.height / 2 + 16.9503, 2);
                    doc.ksEndGroup();
                    doc.ksSymmetryObj(grpVenzOSMirrorX, par1.width / 2, par1.height / 2, par1.width / 2+1,
                        par1.height / 2, "1");

                    reference grpOstVenz = doc.ksNewGroup(0);
                    doc.ksArcBy3Points(par1.width / 2 - 111.62, par1.height / 2 + 0.51, par1.width / 2 - 101.87,
                        par1.height / 2 + 3.57, par1.width / 2 - 92.13, par1.height / 2 + 0.51, 2);

                    doc.ksArcBy3Points(par1.width / 2 - 89.5, par1.height / 2 + 1.98, par1.width / 2 - 88.07,
                        par1.height / 2 + 2.39, par1.width / 2 - 88.36, par1.height / 2 + 3.86,2);
                    doc.ksArcBy3Points(par1.width / 2 - 88.36, par1.height / 2 + 3.86, par1.width / 2 - 91.31,
                        par1.height / 2 + 8.35, par1.width / 2 - 90.77, par1.height / 2 + 13.69, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 90.77, par1.height / 2 + 13.69, par1.width / 2 - 89.32,
                        par1.height / 2 + 14.08, par1.width / 2 - 88.43, par1.height / 2 + 12.87, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 88.43, par1.height / 2 + 12.87, par1.width / 2 - 88.07,
                        par1.height / 2 + 12.56, par1.width / 2 - 87.71, par1.height / 2 + 12.87, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 87.71, par1.height / 2 + 12.87, par1.width / 2 - 87.65,
                        par1.height / 2 + 14.31, par1.width / 2 - 88.11, par1.height / 2 + 15.67, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 88.11, par1.height / 2 + 15.67, par1.width / 2 - 93.3,
                        par1.height / 2 + 17.37, par1.width / 2 - 96.32, par1.height / 2 + 12.81, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 96.32, par1.height / 2 + 12.81, par1.width / 2 - 94.46,
                        par1.height / 2 + 6.42, par1.width / 2 - 89.5, par1.height / 2 + 1.98, 2);

                    doc.ksArcBy3Points(par1.width / 2 - 81.34, par1.height / 2 + 0.87, par1.width / 2 - 72.81,
                        par1.height / 2 + 3.63, par1.width / 2 - 65.42, par1.height / 2 + 8.71, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 65.42, par1.height / 2 + 8.71, par1.width / 2 - 57.52,
                        par1.height / 2 + 10.03, par1.width / 2 - 52.44, par1.height / 2 + 3.83, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 52.44, par1.height / 2 + 3.83, par1.width / 2 - 52.73,
                        par1.height / 2 + 1.9, par1.width / 2 - 54.36, par1.height / 2 + 0.83, 2);

                    doc.ksArcBy3Points(par1.width / 2 - 38.84, par1.height / 2, par1.width / 2 - 37.74,
                        par1.height / 2 + 1.57, par1.width / 2 - 35.89, par1.height / 2 + 1.06, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 35.89, par1.height / 2 + 1.06, par1.width / 2 - 35.35,
                        par1.height / 2 + 0.86, par1.width / 2 - 34.79, par1.height / 2 + 1.03, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 31.91, par1.height / 2 + 6.43, par1.width / 2 - 27.9,
                        par1.height / 2 + 2.44, par1.width / 2 - 22.5, par1.height / 2 + 0.72, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 22.5, par1.height / 2 + 0.72, par1.width / 2 - 22.03,
                        par1.height / 2 + 0.49, par1.width / 2 - 21.83, par1.height / 2, 2);
                    doc.ksLineSeg(par1.width / 2 - 34.79, par1.height / 2 + 1.03, par1.width / 2 - 34.79,
                        par1.height / 2 + 4.41, 2);
                    doc.ksLineSeg(par1.width / 2 - 34.79, par1.height / 2 + 4.41, par1.width / 2 - 31.91,
                        par1.height / 2 + 6.43, 2);

                    doc.ksArcBy3Points(par1.width / 2 - 75.5077, par1.height / 2 + 11.8987, par1.width / 2 - 73.9763,
                        par1.height / 2 + 14.6741, par1.width / 2 - 76.6111, par1.height / 2 + 16.4365, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 76.6111, par1.height / 2 + 16.4365, par1.width / 2 - 74.3091,
                        par1.height / 2 + 20.7785, par1.width / 2 - 69.8752, par1.height / 2 + 22.8981, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 69.8752, par1.height / 2 + 22.8981, par1.width / 2 - 52.5182,
                        par1.height / 2 + 18.5808, par1.width / 2 - 39.9941, par1.height / 2 + 5.8117, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 39.9941, par1.height / 2 + 5.8117, par1.width / 2 - 37.9913,
                        par1.height / 2 + 5.7311, par1.width / 2 - 37.5153, par1.height / 2 + 7.6782, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 37.5153, par1.height / 2 + 7.6782, par1.width / 2 - 46.5773,
                        par1.height / 2 + 19.5488, par1.width / 2 - 59.0307, par1.height / 2 + 27.7916, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 59.0307, par1.height / 2 + 27.7916, par1.width / 2 - 67.4038,
                        par1.height / 2 + 29.1737, par1.width / 2 - 75.5077, par1.height / 2 + 26.6547, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 75.5077, par1.height / 2 + 26.6547, par1.width / 2 - 80.0892,
                        par1.height / 2 + 21.8384, par1.width / 2 - 81.3433, par1.height / 2 + 15.3104, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 81.3433, par1.height / 2 + 15.3104, par1.width / 2 - 79.3099,
                        par1.height / 2 + 12.0920, par1.width / 2 - 75.5077, par1.height / 2 + 11.8987, 2);

                    doc.ksArcBy3Points(par1.width / 2 - 36.8796, par1.height / 2 + 16.9503, par1.width / 2 - 39.9748,
                        par1.height / 2 + 26.6027, par1.width / 2 - 35.7729, par1.height / 2 + 35.8273, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 35.7729, par1.height / 2 + 35.8273, par1.width / 2 - 34.7983,
                        par1.height / 2 + 35.8339, par1.width / 2 - 34.7573, par1.height / 2 + 34.8601, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 34.7573, par1.height / 2 + 34.8601, par1.width / 2 - 35.7956,
                        par1.height / 2 + 33.3114, par1.width / 2 - 36.3832, par1.height / 2 + 31.5419, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 36.3832, par1.height / 2 + 31.5419, par1.width / 2 - 36.1952,
                        par1.height / 2 + 29.7398, par1.width / 2 - 35.0518, par1.height / 2 + 28.3343, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 35.0518, par1.height / 2 + 28.3343, par1.width / 2 - 31.3155,
                        par1.height / 2 + 25.5411, par1.width / 2 - 27.8369, par1.height / 2 + 22.4327, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 27.8369, par1.height / 2 + 22.4327, par1.width / 2 - 27.5206,
                        par1.height / 2 + 21.8002, par1.width / 2 - 27.3843, par1.height / 2 + 21.1062, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 27.3843, par1.height / 2 + 21.1062, par1.width / 2 - 27.1905,
                        par1.height / 2 + 20.8698, par1.width / 2 - 26.9057, par1.height / 2 + 20.9808, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 26.9057, par1.height / 2 + 20.9808, par1.width / 2 - 26.4308,
                        par1.height / 2 + 22.010, par1.width / 2 - 26.2566, par1.height / 2 + 23.130, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 26.2566, par1.height / 2 + 23.130, par1.width / 2 - 26.0927,
                        par1.height / 2 + 24.0742, par1.width / 2 - 25.6456, par1.height / 2 + 24.9217, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 25.6456, par1.height / 2 + 24.9217, par1.width / 2 - 23.5863,
                        par1.height / 2 + 26.7893, par1.width / 2 - 20.9772, par1.height / 2 + 27.7490, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 20.9772, par1.height / 2 + 27.7490, par1.width / 2 - 20.7159,
                        par1.height / 2 + 27.6748, par1.width / 2 - 20.6050, par1.height / 2 + 27.4268, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 20.6050, par1.height / 2 + 27.4268, par1.width / 2 - 20.6693,
                        par1.height / 2 + 26.1442, par1.width / 2 - 20.8195, par1.height / 2 + 24.8688, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 20.8195, par1.height / 2 + 24.8688, par1.width / 2 - 20.7365,
                        par1.height / 2 + 23.3583, par1.width / 2 - 19.7179, par1.height / 2 + 22.2399, 2);
                    doc.ksArcBy3Points(par1.width / 2 - 19.7179, par1.height / 2 + 22.2399, par1.width / 2 - 16.6514,
                        par1.height / 2 + 18.6054, par1.width / 2 - 15.7722, par1.height / 2 + 13.9320, 2);
                    doc.ksEndGroup();

                    reference symmOstVenz = doc.ksSymmetryObj(grpOstVenz, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2-1,
                        "1");
                    doc.ksSymmetryObj(grpOstVenz, par1.width / 2, par1.height / 2, par1.width / 2+1, par1.height / 2,
                        "1");
                    doc.ksSymmetryObj(symmOstVenz, par1.width / 2, par1.height / 2, par1.width / 2 + 1, par1.height / 2,
                        "1");

                    #endregion

                    #region Gravirovka

                    reference grpGrav = doc.ksNewGroup(0);
                    doc.ksLineSeg(11, 57.5125, 11, 114.5749, 2);
                    doc.ksLineSeg(11, 114.5749, 13.4303, 114.5749,2);
                    doc.ksLineSeg(13.4303, 114.5749, 13.4303, 57.5125, 2);
                    doc.ksLineSeg(13.4303, 57.5125, 11, 57.5125, 2);

                    doc.ksLineSeg(16.4328, 56.8170, 16.4328, 107.0443, 2);
                    doc.ksLineSeg(16.4328, 107.0443, 18.7837, 107.0443, 2);
                    doc.ksLineSeg(18.7837, 107.0443, 18.7837, 51.680, 2);
                    doc.ksArcBy3Points(16.4328, 56.8170, 13.8073, 45.1138, 13.8137, 33.1198, 2);
                    doc.ksArcBy3Points(13.8137, 33.1198, 31.5675, 12.0639, 57.4244, 21.5492, 2);
                    doc.ksArcBy3Points(57.4244, 21.5492, 61.6856, 25.3985, 67.3414, 26.3918, 2);
                    doc.ksArcBy3Points(67.3414, 26.3918, 68.0020, 25.2916, 67.1940, 24.2947, 2);
                    doc.ksArcBy3Points(67.1940, 24.2947, 66.6704, 23.6626, 67.1940, 23.0306, 2);
                    doc.ksArcBy3Points(67.1940, 23.0306, 68.0134, 22.9661, 68.8209, 23.1197, 2);
                    doc.ksArcBy3Points(68.8209, 23.1197, 71.1715, 24.0472, 73.6699, 23.6680, 2);
                    doc.ksArcBy3Points(73.6699, 23.6680, 75.1378, 21.3983, 73.6699, 19.1286, 2);
                    doc.ksArcBy3Points(73.6699, 19.1286, 71.8081, 18.7776, 69.9463, 19.1286, 2);
                    doc.ksLineSeg(69.9463, 19.1286, 68.9728, 20.1021, 2);
                    doc.ksArcBy3Points(68.9728, 20.1021, 68.8045, 20.2145, 68.6060, 20.2540, 2);
                    doc.ksLineSeg(68.6060, 20.2540, 67.8601, 20.2540, 2);
                    doc.ksArcBy3Points(67.8601, 20.2540, 67.4933, 20.1021, 67.3414, 19.7353, 2);
                    doc.ksLineSeg(67.3414, 19.7353, 67.3414, 16.0756, 2);
                    doc.ksArcBy3Points(67.3414, 16.0756, 66.6622, 15.2620, 66.2810, 14.2731, 2);
                    doc.ksArcBy3Points(66.2810, 14.2731, 66.8095, 12.1098, 68.8209, 11.1537, 2);
                    doc.ksLineSeg(68.8209, 11.1537, 77.7163, 11.1537, 2);
                    doc.ksArcBy3Points(77.7163, 11.1537, 79.0294, 12.5759, 78.8776, 14.5055, 2);
                    doc.ksArcBy3Points(78.8776, 14.5055, 79.1875, 16.3208, 81.0228, 16.4727, 2);
                    doc.ksArcBy3Points(81.0228, 16.4727, 88.2215, 12.8540, 96.0409, 10.9119, 2);
                    doc.ksArcBy3Points(96.0409, 10.9119, 101.0930, 12.5535, 103.9144, 17.0543, 2);
                    doc.ksArcBy3Points(103.9144, 17.0543, 101.6172, 21.7982, 96.3558, 22.1144, 2);
                    doc.ksArcBy3Points(96.3558, 22.1144, 95.7917, 19.1992, 98.7166, 18.6886, 2);
                    doc.ksArcBy3Points(98.7166, 18.6886, 98.9447, 14.4940, 94.8810, 13.4296, 2);
                    doc.ksArcBy3Points(94.8810, 13.4296, 83.2953, 18.6237, 73.6699, 26.9038, 2);
                    doc.ksArcBy3Points(73.6699, 26.9038, 68.7703, 31.5115, 62.8507, 34.7045, 2);
                    doc.ksArcBy3Points(62.8507, 34.7045, 60.5195, 34.8899, 59.1997, 32.9594, 2);
                    doc.ksArcBy3Points(59.1997, 32.9594, 58.7544, 32.5455, 58.3079, 32.9581, 2);
                    doc.ksArcBy3Points(58.3079, 32.9581, 57.5577, 36.0779, 56.270, 39.0169, 2);
                    doc.ksArcBy3Points(56.270, 39.0169, 66.1260, 37.0336, 73.6699, 30.3880, 2);
                    doc.ksArcBy3Points(73.6699, 30.3880, 64.7747, 42.8522, 49.7525, 45.8213, 2);
                    doc.ksArcBy3Points(49.7525, 45.8213, 43.9927, 48.0773, 37.8098, 48.2689, 2);
                    doc.ksArcBy3Points(37.8098, 48.2689, 27.1912, 51.3653, 22.8233, 61.5272, 2);
                    doc.ksLineSeg(22.8233, 61.5272, 22.8233, 71.9021, 2);
                    doc.ksLineSeg(22.8233, 71.9021, 19.7988, 67.6876, 2);
                    doc.ksLineSeg(19.7988, 67.6876, 19.7988, 64.2518, 2);
                    doc.ksLineSeg(19.7988, 64.2518, 20.9008, 64.2518, 2);
                    doc.ksLineSeg(20.9008, 64.2518, 20.9008, 56.4706, 2);
                    doc.ksArcBy3Points(20.9008, 56.4706, 21.5636, 51.7261, 24.8798, 48.2689, 2);
                    doc.ksLineSeg(24.8798, 48.2689, 24.8798, 46.7408, 2);
                    doc.ksLineSeg(24.8798, 46.7408, 23.1537, 45.9078, 2);
                    doc.ksArcBy3Points(23.1537, 45.9078, 23.0101, 45.7140, 23.0883, 45.4857, 2);
                    doc.ksArcBy3Points(23.0883, 45.4857, 27.3308, 43.4382, 31.9772, 44.2138, 2);
                    doc.ksArcBy3Points(31.9772, 44.2138, 32.4851, 44.1264, 32.5436, 43.6144, 2);
                    doc.ksArcBy3Points(32.5436, 43.6144, 32.3228, 34.0180, 40.3476, 28.7510, 2);
                    doc.ksArcBy3Points(40.3476, 28.7510, 45.9881, 35.2787, 53.8993, 38.7196, 2);
                    doc.ksArcBy3Points(53.8993, 38.7196, 55.4113, 35.5520, 56.1738, 32.1258, 2);
                    doc.ksArcBy3Points(56.1738, 32.1258, 52.5204, 22.1605, 43.9201, 15.9405, 2);
                    doc.ksArcBy3Points(43.9201, 15.9405, 31.5219, 15.9961, 21.3686, 23.1116, 2);
                    doc.ksArcBy3Points(21.3686, 23.1116, 15.7674, 37.0059, 18.7837, 51.680, 2);

                    doc.ksLineSeg(38.7224, 32.7852, 38.7224, 39.9590, 2);
                    doc.ksArcBy3Points(38.7224, 39.9590, 42.3113, 42.8765, 46.4574, 44.9265, 2);
                    doc.ksArcBy3Points(46.4574, 44.9265, 43.8216, 45.7115, 41.0887, 46.0194, 2);
                    doc.ksArcBy3Points(41.0887, 46.0194, 39.2804, 45.7393, 37.6819, 44.8487, 2);
                    doc.ksArcBy3Points(37.6819, 44.8487, 34.9292, 41.3734, 33.8786, 37.0661, 2);
                    doc.ksArcBy3Points(33.8786, 37.0661, 35.2595, 33.7478, 38.7224, 32.7852, 2);
                    doc.ksLineSeg(105.2389, 11.0, 109.2821, 13.3344, 2);
                    doc.ksLineSeg(119.6812, 16.3363, 123.7244, 18.6707, 2);
                    doc.ksEndGroup();

                    reference symmGrav = doc.ksSymmetryObj(grpGrav, par1.width / 2, par1.height / 2, par1.width / 2, par1.height / 2 - 1,
                        "1");
                    reference symmGrav2 = doc.ksSymmetryObj(grpGrav, par1.width / 2, par1.height / 2, par1.width / 2-1, par1.height / 2,
                        "1");
                    reference symmGrav3 = doc.ksSymmetryObj(symmGrav, par1.width / 2, par1.height / 2, par1.width / 2 - 1, par1.height / 2,
                        "1");
                    doc.ksMoveObj(grpGrav, IndentX - 60, IndentY - 60);
                    doc.ksMoveObj(symmGrav, -IndentX + 60, IndentY - 60);
                    doc.ksMoveObj(symmGrav2, IndentX - 60, -IndentY + 60);
                    doc.ksMoveObj(symmGrav3, -IndentX + 60, -IndentY + 60);
                    doc.ksLineSeg(IndentX - 60 + 105.2389, IndentY - 60 + 11, par1.width - IndentX + 60 - 105.2389,
                        IndentY - 60 + 11, 2);
                    doc.ksLineSeg(IndentX - 60 + 109.2821, IndentY - 60 + 13.3344, par1.width - IndentX + 60 - 109.2821,
                        IndentY - 60 + 13.3344, 2);
                    doc.ksLineSeg(IndentX - 60 + 119.6812, IndentY - 60 + 16.3363, par1.width - IndentX + 60 - 119.6812,
                        IndentY - 60 + 16.3363, 2);
                    doc.ksLineSeg(IndentX - 60 + 123.7244, IndentY - 60 + 18.6707, par1.width - IndentX + 60 - 123.7244,
                        IndentY - 60 + 18.6707, 2);
                    doc.ksLineSeg(IndentX - 60 + 105.2389, par1.height -IndentY + 60 - 11, par1.width - IndentX + 60 - 105.2389,
                        par1.height - IndentY + 60 - 11, 2);
                    doc.ksLineSeg(IndentX - 60 + 109.2821, par1.height - IndentY + 60 - 13.3344, par1.width - IndentX + 60 - 109.2821,
                        par1.height - IndentY + 60 - 13.3344, 2);
                    doc.ksLineSeg(IndentX - 60 + 119.6812, par1.height - IndentY + 60 - 16.3363, par1.width - IndentX + 60 - 119.6812,
                        par1.height - IndentY + 60 - 16.3363, 2);
                    doc.ksLineSeg(IndentX - 60 + 123.7244, par1.height - IndentY + 60 - 18.6707, par1.width - IndentX + 60 - 123.7244,
                        par1.height - IndentY + 60 - 18.6707, 2);

                    #endregion
                }
            }
        }
        public static void Piramida3D()
        {
        }
        public static void Style2Dmini()
        {
        }
        public static void Versal()
        {
        }
        public static void Scarlet()
        {
        }
        public static void Reshetka()
        {
        }
        public static void Grafskii()
        {
        }
        public static void FigurnayaKlassika()
        {
        }
        public static void Granada()
        {
        }
        public static void Astoria()
        {
        }
        public static void KvadratSPryamimUglom()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);

                    model1.x = IndentX;
                    model1.y = IndentY;
                    model1.height = par1.height - IndentY * 2;
                    model1.width = par1.width - IndentX * 2;
                    model1.style = 1;
                    doc.ksRectangle(model1);

                    model1.x = IndentX -18;
                    model1.y = IndentY -18;
                    model1.height = par1.height - IndentY * 2 + 36;
                    model1.width = par1.width - IndentX * 2 + 36;
                    model1.style = 7;
                    doc.ksRectangle(model1);

                }
            }
        }
        public static void KvadratnayaViborka()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    
                    model1.x = IndentX;
                    model1.y = IndentY;
                    model1.height = par1.height - IndentY * 2;
                    model1.width = par1.width - IndentX * 2;
                    model1.style = 7;
                    doc.ksRectangle(model1);

                    model1.x = IndentX+8;
                    model1.y = IndentY+8;
                    model1.height = par1.height - IndentY * 2-16;
                    model1.width = par1.width - IndentX * 2-16;
                    model1.style = 1;
                    doc.ksRectangle(model1);

                }
            }
        }
        public static void LzheviborkaKvadratnaya()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);
                    doc.ksLineSeg(0, IndentY, par1.width, IndentY, 1);
                    doc.ksLineSeg(IndentX, IndentY, IndentX, par1.height - IndentY, 1);
                    doc.ksLineSeg(0, par1.height - IndentY, par1.width, par1.height - IndentY, 1);
                    doc.ksLineSeg(par1.width - IndentX, par1.height - IndentY, par1.width - IndentX, IndentY, 1);
                    model1.x = IndentX;
                    model1.y = IndentY;
                    model1.height = par1.height - IndentY * 2;
                    model1.width = par1.width - IndentX * 2;
                    model1.style = 7;
                    doc.ksRectangle(model1);

                }
            }
        }
        public static void Neapol()
        {
            doc = (ksDocument2D)kompas.Document2D();
            DocRecPar(out ksDocumentParam docPar, out ksDocumentParam docPar1, out ksRectangleParam par1,
                out ksRectangleParam model1, out ksRectangleParam model2, out ksRectangleParam model3,
                out ksRectangleParam model4, out ksRectangleParam model5, out ksRectangleParam model6,
                out ksRectangleParam model7, out ksRectangleParam model8, out ksRectangleParam model9,
                out ksRectangleParam model10, out ksRectangleParam model11, out ksRectangleParam model12,
                out ksRectangleParam model13, out ksRectangleParam model14, out ksRectangleParam model15,
                out ksRectangleParam model16, out ksRectangleParam model17, out ksRectangleParam model18,
                out ksRectangleParam model19, out ksRectangleParam model20, out ksRectangleParam model21,
                out ksMathPointParam Point1, out ksMathPointParam Point2);
            if ((docPar != null) & (docPar1 != null))
            {
                docPar.regime = 0;
                docPar.type = (short)DocType.lt_DocFragment;
                doc.ksCreateDocument(docPar);
                {
                    Zagotovka(par1);

                    model1.x = IndentX+15;
                    model1.y = IndentY+15;
                    model1.height = par1.height - IndentY * 2-30;
                    model1.width = par1.width - IndentX * 2-30;
                    model1.style = 1;
                    doc.ksRectangle(model1);

                    model2.x = IndentX + 21;
                    model2.y = IndentY + 21;
                    model2.height = par1.height - IndentY * 2 - 42;
                    model2.width = par1.width - IndentX * 2 - 42;
                    model2.style = 1;
                    doc.ksRectangle(model2);

                    model3.x = IndentX + 31;
                    model3.y = IndentY + 31;
                    model3.height = par1.height - IndentY * 2 - 62;
                    model3.width = par1.width - IndentX * 2 - 62;
                    model3.style = 1;
                    doc.ksRectangle(model3);

                    model4.x = IndentX + 8;
                    model4.y = IndentY + 8;
                    model4.height = par1.height - IndentY * 2 - 16;
                    model4.width = par1.width - IndentX * 2 - 16;
                    model4.style = 7;
                    doc.ksRectangle(model4);

                    model5.x = IndentX + 12;
                    model5.y = IndentY + 12;
                    model5.height = par1.height - IndentY * 2 - 24;
                    model5.width = par1.width - IndentX * 2 - 24;
                    model5.style = 7;
                    doc.ksRectangle(model5);

                    model6.x = IndentX + 16;
                    model6.y = IndentY + 16;
                    model6.height = par1.height - IndentY * 2 - 32;
                    model6.width = par1.width - IndentX * 2 - 32;
                    model6.style = 7;
                    doc.ksRectangle(model6);

                    model7.x = IndentX;
                    model7.y = IndentY;
                    model7.height = par1.height - IndentY * 2;
                    model7.width = par1.width - IndentX * 2;
                    model7.style = 7;
                    doc.ksRectangle(model7);

                    doc.ksBezier(0, 7);
                    doc.ksPoint(IndentX+1.75, IndentY +0.99,7);
                    doc.ksPoint(IndentX +1.73, IndentY +1.06, 7);
                    doc.ksPoint(IndentX +1.36, IndentY +2.12, 7);
                    doc.ksPoint(IndentX + 0.09, IndentY + 4.98, 7);
                    doc.ksPoint(IndentX +0.02, IndentY +5.38, 7);
                    doc.ksPoint(IndentX +0.06, IndentY +5.58, 7);
                    doc.ksPoint(IndentX + 0.8, IndentY + 5.99, 7);
                    doc.ksPoint(IndentX +1.93, IndentY +6.25, 7);
                    doc.ksPoint(IndentX +4.92, IndentY +6.21, 7);
                    doc.ksPoint(IndentX +6.79, IndentY +5.36, 7);
                    doc.ksPoint(IndentX + 7.74, IndentY + 4.3, 7);
                    doc.ksPoint(IndentX + 8.5, IndentY + 3.13, 7);
                    doc.ksPoint(IndentX + 9.22, IndentY + 2.18, 7);
                    doc.ksPoint(IndentX +10.92, IndentY +0.75, 7);
                    doc.ksPoint(IndentX +14.56, IndentY +0.05, 7);
                    doc.ksPoint(IndentX +17.01, IndentY +0.99, 7);
                    int Elem_PletX = doc.ksEndObj();

                    Point1.x = (Shirina-IndentX*2) / 7.63;
                    for (int i = 1; i <= Point1.x; i++)
                    {
                        doc.ksCopyObj(Elem_PletX, IndentX + 1.75, IndentY + 0.99, IndentX + 1.75 + 7.63 * i,
                            IndentY + 0.99, 1, 0);
                    }
                    //нижняя часть по Х
                    doc.ksBezier(0, 7);
                    doc.ksPoint(IndentX + 0.99, IndentY + 7.86, 7);
                    doc.ksPoint(IndentX + 1.06, IndentY + 7.84, 7);
                    doc.ksPoint(IndentX + 2.12, IndentY + 7.47, 7);
                    doc.ksPoint(IndentX + 4.98, IndentY + 6.2, 7);
                    doc.ksPoint(IndentX + 5.38, IndentY + 6.13, 7);
                    doc.ksPoint(IndentX + 5.58, IndentY + 6.17, 7);
                    doc.ksPoint(IndentX + 5.99, IndentY + 6.91, 7);
                    doc.ksPoint(IndentX + 6.25, IndentY + 8.04, 7);
                    doc.ksPoint(IndentX + 6.21, IndentY + 11.03, 7);
                    doc.ksPoint(IndentX + 5.36, IndentY + 12.9, 7);
                    doc.ksPoint(IndentX + 4.3, IndentY + 13.85, 7);
                    doc.ksPoint(IndentX + 3.13, IndentY + 14.61, 7);
                    doc.ksPoint(IndentX + 2.18, IndentY + 15.33, 7);
                    doc.ksPoint(IndentX + 0.75, IndentY + 17.03, 7);
                    doc.ksPoint(IndentX + 0.05, IndentY + 20.67, 7);
                    doc.ksPoint(IndentX + 0.99, IndentY + 23.12, 7);
                    int Elem_PletY = doc.ksEndObj();
                    Point1.y = (Visota - IndentY * 2) / 7.63;
                    for (int i = 1; i <= Point1.y-1; i++)
                    {
                        doc.ksCopyObj(Elem_PletY, IndentX + 0.99, IndentY + 7.86, IndentX + 0.99,
                            IndentY + 7.86 + 7.63*i, 1, 0);
                    }
                    //Левая часть по У
                    doc.ksDeleteObj(Elem_PletX);
                    doc.ksDeleteObj(Elem_PletY);

                    doc.ksBezier(0, 7);
                    doc.ksPoint(IndentX + 1.75 + 7.63, IndentY + 0.99, 7);
                    doc.ksPoint(IndentX + 6.93, IndentY + 0.05, 7);
                    doc.ksPoint(IndentX + 3.29, IndentY + 0.75, 7);
                    doc.ksPoint(IndentX + 1.59, IndentY + 2.18, 7);
                    doc.ksPoint(IndentX + 0.92, IndentY + 3.06, 7);
                    doc.ksPoint(IndentX + 0.09, IndentY + 4.98, 7);
                    doc.ksPoint(IndentX + 0.02, IndentY + 5.38, 7);
                    doc.ksPoint(IndentX + 0.06, IndentY + 5.58, 7);
                    doc.ksPoint(IndentX + 0.8, IndentY + 5.99, 7);
                    doc.ksPoint(IndentX + 1.93, IndentY + 6.25, 7);
                    doc.ksPoint(IndentX + 4.92, IndentY + 6.21, 7);
                    doc.ksPoint(IndentX + 6.79, IndentY + 5.36, 7);
                    doc.ksPoint(IndentX + 7.74, IndentY + 4.3, 7);
                    doc.ksPoint(IndentX + 8.5, IndentY + 3.13, 7);
                    doc.ksPoint(IndentX + 9.22, IndentY + 2.18, 7);
                    doc.ksPoint(IndentX + 10.92, IndentY + 0.75, 7);
                    doc.ksPoint(IndentX + 14.56, IndentY + 0.05, 7);
                    doc.ksPoint(IndentX + 17.01, IndentY + 0.99, 7);
                    doc.ksEndObj();//Первый элемент по Х низ (изменены и добавлены первые пять элементов)

                    doc.ksBezier(0, 7);
                    doc.ksPoint(IndentX + 0.99,IndentY + 7.86 + 7.63, 7);
                    doc.ksPoint(IndentX + 0.05, IndentY + 20.67-7.63, 7);
                    doc.ksPoint(IndentX + 0.75, IndentY + 17.03-7.63, 7);
                    doc.ksPoint(IndentX + 2.18, IndentY + 15.33-7.63, 7);
                    doc.ksPoint(IndentX + 3.06, IndentY + 7.03, 7);
                    doc.ksPoint(IndentX + 4.98, IndentY + 6.2, 7);
                    doc.ksPoint(IndentX + 5.38, IndentY + 6.13, 7);
                    doc.ksPoint(IndentX + 5.58, IndentY + 6.17, 7);
                    doc.ksPoint(IndentX + 5.99, IndentY + 6.91, 7);
                    doc.ksPoint(IndentX + 6.25, IndentY + 8.04, 7);
                    doc.ksPoint(IndentX + 6.21, IndentY + 11.03, 7);
                    doc.ksPoint(IndentX + 5.36, IndentY + 12.9, 7);
                    doc.ksPoint(IndentX + 4.3, IndentY + 13.85, 7);
                    doc.ksPoint(IndentX + 3.13, IndentY + 14.61, 7);
                    doc.ksPoint(IndentX + 2.18, IndentY + 15.33, 7);
                    doc.ksPoint(IndentX + 0.75, IndentY + 17.03, 7);
                    doc.ksPoint(IndentX + 0.05, IndentY + 20.67, 7);
                    doc.ksPoint(IndentX + 0.99, IndentY + 23.12, 7);
                    doc.ksEndObj();//Первый элемент по У лево (изменены и добавлены первые пять элементов)

                    doc.ksBezier(0, 7);
                    doc.ksPoint(IndentX + 1.75 + 6.22, par1.height - IndentY - 6.38 + 0.99, 7);
                    doc.ksPoint(IndentX + 1.73 + 6.22, par1.height - IndentY - 6.38 + 1.06, 7);
                    doc.ksPoint(IndentX + 1.36 + 6.22, par1.height - IndentY - 6.38 + 2.12, 7);
                    doc.ksPoint(IndentX + 0.09 + 6.22, par1.height - IndentY - 6.38 + 4.98, 7);
                    doc.ksPoint(IndentX + 0.02 + 6.22, par1.height - IndentY - 6.38 + 5.38, 7);
                    doc.ksPoint(IndentX + 0.06 + 6.22, par1.height - IndentY - 6.38 + 5.58, 7);
                    doc.ksPoint(IndentX + 0.8 + 6.22, par1.height - IndentY - 6.38 + 5.99, 7);
                    doc.ksPoint(IndentX + 1.93 + 6.22, par1.height - IndentY - 6.38 + 6.25, 7);
                    doc.ksPoint(IndentX + 4.92 + 6.22, par1.height - IndentY - 6.38 + 6.21, 7);
                    doc.ksPoint(IndentX + 6.79 + 6.22, par1.height - IndentY - 6.38 + 5.36, 7);
                    doc.ksPoint(IndentX + 7.74 + 6.22, par1.height - IndentY - 6.38 + 4.3, 7);
                    doc.ksPoint(IndentX + 8.5 + 6.22, par1.height - IndentY - 6.38 + 3.13, 7);
                    doc.ksPoint(IndentX + 9.22 + 6.22, par1.height - IndentY - 6.38 + 2.18, 7);
                    doc.ksPoint(IndentX + 10.92 + 6.22, par1.height - IndentY - 6.38 + 0.75, 7);
                    doc.ksPoint(IndentX + 14.56 + 6.22, par1.height - IndentY - 6.38 + 0.05, 7);
                    doc.ksPoint(IndentX + 17.01 + 6.22, par1.height - IndentY - 6.38 + 0.99, 7);
                    int Elem_PletXtop = doc.ksEndObj();
                    for (int i = 1; i <= Point1.x-1; i++)
                    {
                        doc.ksCopyObj(Elem_PletXtop, IndentX + 1.75 + 6.22, par1.height - IndentY - 6.38 + 0.99, IndentX + 1.75 + 6.22 + 7.63 * i,
                            par1.height - IndentY - 6.38 + 0.99, 1, 0);
                    }
                    //верхняя часть по Х
                    doc.ksBezier(0, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.99, IndentY + 7.86, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 1.06, IndentY + 7.84, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 2.12, IndentY + 7.47, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 4.98, IndentY + 6.2, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 5.38, IndentY + 6.13, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 5.58, IndentY + 6.17, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 5.99, IndentY + 6.91, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 6.25, IndentY + 8.04, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 6.21, IndentY + 11.03, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 5.36, IndentY + 12.9, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 4.3, IndentY + 13.85, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 3.13, IndentY + 14.61, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 2.18, IndentY + 15.33, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.75, IndentY + 17.03, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.05, IndentY + 20.67, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.99, IndentY + 23.12, 7);
                    int Elem_PletYright = doc.ksEndObj();
                    Point1.y = (Visota - IndentY * 2) / 7.63;
                    for (int i = 1; i <= Point1.y-2; i++)
                    {
                        doc.ksCopyObj(Elem_PletYright, par1.width - IndentX - 6.38 + 0.99, IndentY + 7.86, par1.width - IndentX - 6.38 + 0.99,
                            IndentY + 7.86 + 7.63 * i, 1, 0);
                    }
                    //Правая часть по У (у здесь тот же что и в левой части можно ниже на 0.35(из расчета))
                    doc.ksDeleteObj(Elem_PletXtop);
                    doc.ksDeleteObj(Elem_PletYright);

                    doc.ksBezier(0, 7);
                    doc.ksPoint(IndentX + 1.75 + 7.63 + 6.22, par1.height - IndentY - 6.38 + 0.99, 7);
                    doc.ksPoint(IndentX + 6.93 + 6.22, par1.height - IndentY - 6.38 + 0.05, 7);
                    doc.ksPoint(IndentX + 3.29 + 6.22, par1.height - IndentY - 6.38 + 0.75, 7);
                    doc.ksPoint(IndentX + 1.59 + 6.22, par1.height - IndentY - 6.38 + 2.18, 7);
                    doc.ksPoint(IndentX + 0.92 + 6.22, par1.height - IndentY - 6.38 + 3.06, 7);
                    doc.ksPoint(IndentX + 0.09 + 6.22, par1.height - IndentY - 6.38 + 4.98, 7);
                    doc.ksPoint(IndentX + 0.02 + 6.22, par1.height - IndentY - 6.38 + 5.38, 7);
                    doc.ksPoint(IndentX + 0.06 + 6.22, par1.height - IndentY - 6.38 + 5.58, 7);
                    doc.ksPoint(IndentX + 0.8 + 6.22, par1.height - IndentY - 6.38 + 5.99, 7);
                    doc.ksPoint(IndentX + 1.93 + 6.22, par1.height - IndentY - 6.38 + 6.25, 7);
                    doc.ksPoint(IndentX + 4.92 + 6.22, par1.height - IndentY - 6.38 + 6.21, 7);
                    doc.ksPoint(IndentX + 6.79 + 6.22, par1.height - IndentY - 6.38 + 5.36, 7);
                    doc.ksPoint(IndentX + 7.74 + 6.22, par1.height - IndentY - 6.38 + 4.3, 7);
                    doc.ksPoint(IndentX + 8.5 + 6.22, par1.height - IndentY - 6.38 + 3.13, 7);
                    doc.ksPoint(IndentX + 9.22 + 6.22, par1.height - IndentY - 6.38 + 2.18, 7);
                    doc.ksPoint(IndentX + 10.92 + 6.22, par1.height - IndentY - 6.38 + 0.75, 7);
                    doc.ksPoint(IndentX + 14.56 + 6.22, par1.height - IndentY - 6.38 + 0.05, 7);
                    doc.ksPoint(IndentX + 17.01 + 6.22, par1.height - IndentY - 6.38 + 0.99, 7);
                    doc.ksEndObj();
                    //Первый элемент верхней части по Х

                    doc.ksBezier(0, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.99, IndentY + 7.86 + 7.63, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.05, IndentY + 20.67 - 7.63, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.75, IndentY + 17.03 - 7.63, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 2.18, IndentY + 15.33 - 7.63, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 3.06, IndentY + 7.03, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 4.98, IndentY + 6.2, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 5.38, IndentY + 6.13, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 5.58, IndentY + 6.17, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 5.99, IndentY + 6.91, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 6.25, IndentY + 8.04, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 6.21, IndentY + 11.03, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 5.36, IndentY + 12.9, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 4.3, IndentY + 13.85, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 3.13, IndentY + 14.61, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 2.18, IndentY + 15.33, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.75, IndentY + 17.03, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.05, IndentY + 20.67, 7);
                    doc.ksPoint(par1.width - IndentX - 6.38 + 0.99, IndentY + 23.12, 7);
                    doc.ksEndObj();
                    //Первый элемент правой части по У
                }
            }
        }
        public static void KvadratSPramimUglomSlozhnii()
        {
        }
        #endregion

        [return: MarshalAs(UnmanagedType.BStr)]
        public string GetLibraryName()
        {
            return "Automation";
        }

        [return: MarshalAs(UnmanagedType.BStr)]

        #region Меню библиотеки

        public string ExternalMenuItem(short number, ref short itemType, ref short command)
        {
            string result = string.Empty;
            itemType = 1; // "MENUITEM"
            
            switch (number)
            {
                case 1:
                    result = "Накладки";
                    command = 210;
                    break;
                case 2:
                    result = "Фасады";
                    command = 211;
                    break;
                case 3:
                    command = -1;
                    itemType = 213; // "ENDMENU"
                    break;
            }
            return result; 
        }

        #endregion

        public void ExternalRunCommand([In]short command, [In] short mode, [In, MarshalAs(UnmanagedType.IDispatch)]object kompas_)
        {
            kompas = (KompasObject) kompas_;
            if (kompas == null) return;
            if (command >= 1) /*опредляется что при выборе создасться документ(иначе причется создавать фрагмент самому,
                а затем использовать функцию)....решение давать переменную или просто определить диапазон кол-ва накладок*/
                doc = (Document2D) kompas.Document2D();
            else
                doc = (Document2D) kompas.ActiveDocument2D();
            if (doc == null) return;
            
            switch (command)
            {
                case 210:
                    Instance.ShowDialog(); //главный запуск приложения(для отдельного окна со всеми настройками)
                    break;
                case 211:
                    Instancef.ShowDialog(); //главный запуск приложения(для отдельного окна со всеми настройками)
                    break;
            }
        }

        #region Реализаця интерфейса IDisposable

        public void Dispose()
        {
            if (kompas != null)
            {
                Marshal.ReleaseComObject(Global.Kompas);
                GC.SuppressFinalize(Global.Kompas);
                kompas = null;
            }
        }

        #endregion

        #region COM Registration

        // Эта функция выполняется при регистрации класса для COM
        // Она добавляет в ветку реестра компонента раздел Kompas_Library,
        // который сигнализирует о том, что класс является приложением Компас,
        // а также заменяет имя InprocServer32 на полное, с указанием пути.
        // Все это делается для того, чтобы иметь возможность подключить
        // библиотеку на вкладке ActiveX.
        [ComRegisterFunction]
        public static void RegisterKompasLib(Type t)
        {
            try
            {
                RegistryKey regKey = Registry.LocalMachine;
                string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
                regKey = regKey.OpenSubKey(keyName, true);
                regKey.CreateSubKey("Kompas_Library");
                regKey = regKey.OpenSubKey("InprocServer32", true);
                regKey.SetValue(null,
                    System.Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\mscoree.dll");
                regKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("При регистрации класса для COM-Interop произошла ошибка:\n{0}", ex));
            }
        }

        // Эта функция удаляет раздел Kompas_Library из реестра
        [ComUnregisterFunction]
        public static void UnregisterKompasLib(Type t)
        {
            RegistryKey regKey = Registry.LocalMachine;
            string keyName = @"SOFTWARE\Classes\CLSID\{" + t.GUID.ToString() + "}";
            RegistryKey subKey = regKey.OpenSubKey(keyName, true);
            subKey.DeleteSubKey("Kompas_Library");
            subKey.Close();
        }

        #endregion
    }
}