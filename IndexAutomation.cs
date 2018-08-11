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



namespace Steps.NET
{

    [ClassInterface(ClassInterfaceType.AutoDual)]
    public partial class Step3
    {
        public static KompasObject kompas;
        public static ksDocument2D doc;
        public static float Visota { get; set; }
        public static float Shirina { get; set; }
        

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
                reference _cur1 = doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, Point2.x, Point1.y, Point2.x, Point1.y + model2.height, 1, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, par1.width - 140, 140,
                    1); // x1, y1, x2, y2, стиль линии
                doc.ksLineSeg(par1.width - 140, 140, par1.width - 140, (par1.height / 2) - 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, model1.width + 160 + model2.width + 265,
                    ((par1.height) / 2) - (model2.height / 2) - 80, 1);
                doc.ksLineSeg(par1.width - 140, (par1.height / 2) - 40,
                    par1.width - 140 - model2.height - (((30))) /*просто убери число в кавычках*/,
                    (par1.height / 2) - 40, 1);
                // doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2, (model2.height / 2) + 80, Point2.x, Point1.y, par1.width - 140 - model2.height, (par1.height / 2) - 40, 1, 1);
                doc.ksTrimmCurve(_cur1, Point2.x, 140 + model2.height, Point2.x, (par1.height / 2) - 40 - 80,
                    Point2.x + model2.height / 2 + 80, par1.height / 2,
                    1); // усекатель x1y1точки начала дуги x2y2-точки конца x3y3 точка усечения 1/0 удалять/оставлять после усечения
                doc.ksTrimmCurve(_cur1, Point2.x, 140 + model2.height, Point2.x, (par1.height / 2) - 40 - 80,
                    Point2.x + model2.height / 2 + 80, par1.height / 2, 1);
                // Элемент 5
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    par1.width - 140, 140 + 80 * 2 + model2.height * 3, 1); // x1, y1, x2, y2, стиль линии
                doc.ksLineSeg(par1.width - 140, 140 + 80 * 2 + model2.height * 3, par1.width - 140,
                    (par1.height / 2) + 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    model1.width + 160 + model2.width + 265, ((par1.height) / 2) + (model2.height / 2) + 80, 1);
                doc.ksLineSeg(par1.width - 140, (par1.height / 2) + 40,
                    par1.width - 140 - model2.height - (((30))) /*просто убери число в кавычках*/,
                    (par1.height / 2) + 40, 1);
                //doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2, model2.height / 2 + 80, Point2.x, Point1.y, par1.width - 140 - model2.height, (par1.height / 2) + 40, 1, 1);
                // Элемент 6                
                // ksIntersectionResult
                // doc.ksTrimmCurve(_cur2); // усекатель
            }
        } // с комментами по дугам и линиям (bug с усекателем в x3 и y3)

        public static void Econom18()
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
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height = (par1.height - 280);
                //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
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
                model4.x = 265 + 80 + model1.width;
                model4.y = 140 + 80 + model2.height;
                model4.height = ((par1.height - 280) - 160) / 3;
                model4.width = ((par1.width - 405) - 160) - model1.width - par1.width / 4;
                model4.style = 1;
                doc.ksRectangle(model4);
                Point1.x = 265 + 80 + model1.width; 
                Point1.y = 140 + 80 + model2.height; //Point1 точка начала отрезка
                Point2.x = model2.width + 80 + 265 + 80 + model1.width; //
                Point2.y = 140 + 80 + model2.height; //Point2 точка конца отрезка                
                doc.ksLineSeg(Point1.x + model4.width + 80, Point1.y, Point2.x, Point2.y, 1);
                doc.ksLineSeg(Point1.x + model4.width + 80, Point1.y + model2.height, Point2.x,
                    Point1.y + model2.height, 1);
                doc.ksLineSeg(Point1.x + model4.width + 80, Point1.y, Point1.x + model4.width + 80,
                    Point1.y + model2.height, 1);
                doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2, model2.height / 2, Point2.x,
                    Point1.y, Point2.x, Point1.y + model2.height, 1, 1); //xc, yc, rad, x1, y1, x2, y2, direction, style
                //Элемент 4
                reference _cur1 = doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, Point2.x, Point1.y, Point2.x, Point1.y + model2.height, 1, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, par1.width - 140, 140, 1);
                // x1, y1, x2, y2, стиль линии
                doc.ksLineSeg(par1.width - 140, 140, par1.width - 140, (par1.height / 2) - 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, model1.width + 160 + model2.width + 265,
                    ((par1.height) / 2) - (model2.height / 2) - 80, 1);
                doc.ksLineSeg(par1.width - 140, (par1.height / 2) - 40, par1.width - 140 - model2.height - (((30)))
                    /*просто убери число в кавычках*/, (par1.height / 2) - 40, 1);
                // doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2, (model2.height / 2) + 80, Point2.x, Point1.y, par1.width - 140 - model2.height, (par1.height / 2) - 40, 1, 1);
                doc.ksTrimmCurve(_cur1, Point2.x, 140 + model2.height, Point2.x, (par1.height / 2) - 40 - 80,
                    Point2.x + model2.height / 2 + 80, par1.height / 2, 1);
                // усекатель x1y1точки начала дуги x2y2-точки конца x3y3 точка усечения 1/0 удалять/оставлять после усечения
                doc.ksTrimmCurve(_cur1, Point2.x, 140 + model2.height, Point2.x, (par1.height / 2) - 40 - 80,
                    Point2.x + model2.height / 2 + 80, par1.height / 2, 1);
                // Элемент 5
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    par1.width - 140, 140 + 80 * 2 + model2.height * 3, 1); // x1, y1, x2, y2, стиль линии
                doc.ksLineSeg(par1.width - 140, 140 + 80 * 2 + model2.height * 3, par1.width - 140,
                    (par1.height / 2) + 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    model1.width + 160 + model2.width + 265, ((par1.height) / 2) + (model2.height / 2) + 80, 1);
                doc.ksLineSeg(par1.width - 140, (par1.height / 2) + 40, par1.width - 140 - model2.height - (((30)))
                    /*просто убери число в кавычках*/, (par1.height / 2) + 40, 1);
                // Элемент 6                
            }
        } //bug как с 17 моделью

        public static void Econom19()
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
                model1.x = 265; //местоположение элемента (отступы)
                model1.y = 140;
                model1.height = ((par1.height - 280) - 160) / 3;
                //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model1.width = ((par1.width - 405) - 480) / 5; // 
                model1.style = 1;
                doc.ksRectangle(model1); //отрисовка элемента 1
                model4.x = 265; //местоположение элемента (отступы)
                model4.y = 140 + 80 + model1.height;
                model4.height = ((par1.height - 280) - 160) / 3;
                //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model4.width = ((par1.width - 405) - 480) / 5; // 
                model4.style = 1;
                doc.ksRectangle(model4); //отрисовка элемента 1
                model5.x = 265; //местоположение элемента (отступы)
                model5.y = 140 + 80 * 2 + model1.height * 2;
                model5.height = ((par1.height - 280) - 160) / 3;
                //размер элемента ((высота|ширина заготовки - сумма отступов с двух сторон - сумма отступов между элементами)/ количество строк|столбцов)
                model5.width = ((par1.width - 405) - 480) / 5; // 
                model5.style = 1;
                doc.ksRectangle(model5); //отрисовка элемента 1
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
                Point1.x = 265 + 80 + model1.width; //
                Point1.y = 140 + 80 + model2.height; //Point1 точка начала отрезка
                Point2.x = model2.width + 80 + 265 + 80 + model1.width; //
                Point2.y = 140 + 80 + model2.height; //Point2 точка конца отрезка                
                doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                doc.ksLineSeg(Point1.x, Point1.y + model2.height, Point2.x, Point1.y + model2.height, 1);
                doc.ksLineSeg(Point1.x, Point1.y, Point1.x, Point1.y + model2.height, 1);
                doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2, model2.height / 2, Point2.x,
                    Point1.y, Point2.x, Point1.y + model2.height, 1, 1); //xc, yc, rad, x1, y1, x2, y2, direction, style
                reference _cur1 = doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2,
                    model2.height / 2 + 80, Point2.x, Point1.y, Point2.x, Point1.y + model2.height, 1, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, par1.width - 140, 140, 1);
                // x1, y1, x2, y2, стиль линии
                doc.ksLineSeg(par1.width - 140, 140, par1.width - 140, (par1.height / 2) - 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140, model1.width + 160 + model2.width + 265,
                    ((par1.height) / 2) - (model2.height / 2) - 80, 1);
                doc.ksLineSeg(par1.width - 140, (par1.height / 2) - 40, par1.width - 140 - model2.height - (((30)))
                    /*просто убери число в кавычках*/, (par1.height / 2) - 40, 1);
                // doc.ksArcByPoint(265 + model1.width + 160 + model2.width, par1.height / 2, (model2.height / 2) + 80, Point2.x, Point1.y, par1.width - 140 - model2.height, (par1.height / 2) - 40, 1, 1);
                doc.ksTrimmCurve(_cur1, Point2.x, 140 + model2.height, Point2.x, (par1.height / 2) - 40 - 80,
                    Point2.x + model2.height / 2 + 80, par1.height / 2, 1);
                // усекатель x1y1точки начала дуги x2y2-точки конца x3y3 точка усечения 1/0 удалять/оставлять после усечения
                doc.ksTrimmCurve(_cur1, Point2.x, 140 + model2.height, Point2.x, (par1.height / 2) - 40 - 80,
                    Point2.x + model2.height / 2 + 80, par1.height / 2, 1);
                // Элемент 5
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    par1.width - 140, 140 + 80 * 2 + model2.height * 3, 1); // x1, y1, x2, y2, стиль линии
                doc.ksLineSeg(par1.width - 140, 140 + 80 * 2 + model2.height * 3, par1.width - 140,
                    (par1.height / 2) + 40, 1);
                doc.ksLineSeg(model1.width + 160 + model2.width + 265, 140 + 80 * 2 + model2.height * 3,
                    model1.width + 160 + model2.width + 265, ((par1.height) / 2) + (model2.height / 2) + 80, 1);
                doc.ksLineSeg(par1.width - 140, (par1.height / 2) + 40, par1.width - 140 - model2.height - (((30)))
                    /*просто убери число в кавычках*/, (par1.height / 2) + 40, 1);
                // Элемент 6                
            } //как модель 17 только 1 элемент разделен на 3(баг с 17 моделью)
        } // bug как с 17 моделью

        public static void Econom20()
        {
        }

        public static void Econom21()
        {
        }

        public static void Econom22()
        {
        }

        public static void Econom23()
        {
        }

        public static void Econom24()
        {
        }

        public static void Econom25()
        {
        }

        public static void Econom26()
        {
        }

        public static void Econom27()
        {
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
        }

        public static void Econom35()
        {
        }

        public static void Econom36()
        {
        }

        public static void Econom37()
        {
        }

        public static void Econom38()
        {
        }

        public static void Econom39()
        {
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
                    doc.ksArcByPoint(265, 140, 80, 265 + 80, 140, 265, 140 + 80, 1, 1);
                    doc.ksArcByPoint(265, par1.height - 140, 80, 265 + 80, par1.height - 140, 265,
                        par1.height - 140 - 80, -1, 1);
                    doc.ksArcByPoint(par1.width - 190, 140, 80, par1.width - 190 - 80, 140, par1.width - 190, 140 + 80,
                        -1, 1);
                    doc.ksArcByPoint(par1.width - 190, par1.height - 140, 80, par1.width - 190 - 80, par1.height - 140,
                        par1.width - 190, par1.height - 140 - 80, 1, 1);
                    doc.ksArcBy3Points(par1.width - 190, 140 + 80, par1.width - 140, par1.height / 2, par1.width - 190,
                        par1.height - 140 - 80, 1);
                    doc.ksLineSeg(265 + 80, 140, par1.width - 190 - 80, 140, 1);
                    doc.ksLineSeg(265, 140 + 80, 265, par1.height - 140 - 80, 1);
                    doc.ksLineSeg(265 + 80, par1.height - 140, par1.width - 190 - 80, par1.height - 140, 1);
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
        }

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
                    model1.x = 140; //отступы рисунка на заготовке
                    model1.y = 140;
                    model1.height = par1.height - 280;
                    model1.width = par1.width - 280;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    Point1.x = model1.width / 5 + 140; //
                    Point1.y = 140; //Point1 точка начала отрезка
                    Point2.x = model1.width / 5 + 140; //
                    Point2.y = par1.height - 140; //Point2 точка конца отрезка                
                    doc.ksLineSeg(Point1.x, Point1.y, Point2.x, Point2.y, 1);
                    doc.ksLineSeg((model1.width / 5) * 2 + 140, Point1.y, (model1.width / 5) * 2 + 140, Point2.y, 1);
                    doc.ksLineSeg((model1.width / 5) * 3 + 140, Point1.y, (model1.width / 5) * 3 + 140, Point2.y, 1);
                    doc.ksLineSeg((model1.width / 5) * 4 + 140, Point1.y, (model1.width / 5) * 4 + 140, Point2.y, 1);
                }
            }
        }

        public static void Econom46()
        {
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
                    model1.x = 140; //отступы рисунка на заготовке
                    model1.y = 140;
                    model1.height = par1.height - 280;
                    model1.width = par1.width - 280;
                    model1.style = 1;
                    doc.ksRectangle(model1);
                    Point1.x = 140; //
                    Point1.y = model1.height + 140; //Point1 точка начала отрезка
                    Point2.x = model1.height + 140; //
                    Point2.y = 140; //Point2 точка конца отрезка                
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
        }//Пример поворота обьекта(на примере линии)Bug отрезать окружность и добавить симметрию

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
        }

        public static void Econom68()
        {
        }

        public static void Econom69()
        {
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
        }//Цикличная отрисовка Bug переделать алгоритм

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
                    result = "Главный запуск приложения";
                    command = 210;
                    break;
                case 2:
                    command = -1;
                    itemType = 212; // "ENDMENU"
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