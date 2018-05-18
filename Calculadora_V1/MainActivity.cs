using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Content;
using System;

namespace Calculadora_V1
{
    [Activity(Label = "Calculadora V1", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button UNO      = null;
        Button DOS      = null;
        Button TRES     = null;
        Button CUATRO   = null;
        Button CINCO    = null;
        Button SEIS     = null;
        Button SIETE    = null;
        Button OCHO     = null;
        Button NUEVE    = null;
        Button CERO     = null;

        Button PUNTO    = null;

        EditText VALOR  = null;

        Button CLOSE    = null;
        Button C        = null;
        Button CM       = null;
        Button M        = null;

        Button SUMA             = null;
        Button RESTA            = null;
        Button DIVISION         = null;
        Button MULTIPLICACION   = null;
        Button IGUAL            = null;

        double Valor1 = 0.0;
        double Valor2 = 0.0;
        double Memoria = 0.0;
        string operacion = "";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            /*
                Interfaces en linea
             */
            Valor1 = 0.0;
            Valor2 = 0.0;
            Memoria = 0.0;
            operacion = "";
            UNO     = FindViewById<Button>(Resource.Id.UNO);
            DOS     = FindViewById<Button>(Resource.Id.DOS);
            TRES    = FindViewById<Button>(Resource.Id.TRES);
            CUATRO  = FindViewById<Button>(Resource.Id.CUATRO);
            CINCO   = FindViewById<Button>(Resource.Id.CINCO);
            SEIS    = FindViewById<Button>(Resource.Id.SEIS);
            SIETE   = FindViewById<Button>(Resource.Id.SIETE);
            OCHO    = FindViewById<Button>(Resource.Id.OCHO);
            NUEVE   = FindViewById<Button>(Resource.Id.NUEVE);
            CERO    = FindViewById<Button>(Resource.Id.CERO);

            PUNTO   = FindViewById<Button>(Resource.Id.PUNTO);

            VALOR   = FindViewById<EditText>(Resource.Id.VALOR);

            CLOSE   = FindViewById<Button>(Resource.Id.CLOSE);
            C       = FindViewById<Button>(Resource.Id.C);
            CM      = FindViewById<Button>(Resource.Id.CM);
            M       = FindViewById<Button>(Resource.Id.M);

            MULTIPLICACION  = FindViewById<Button>(Resource.Id.MULTIPLICACION);
            SUMA            = FindViewById<Button>(Resource.Id.SUMA);
            RESTA           = FindViewById<Button>(Resource.Id.MENOS);
            DIVISION        = FindViewById<Button>(Resource.Id.DIVIDIR);
            IGUAL           = FindViewById<Button>(Resource.Id.IGUAL);

            UNO.Click += delegate{
                VALOR.Text = VALOR.Text + "1";
            };
            DOS.Click += delegate {
                VALOR.Text = VALOR.Text + "2";
            };
            TRES.Click += delegate {
                VALOR.Text = VALOR.Text + "3";
            };
            CUATRO.Click += delegate {
                VALOR.Text = VALOR.Text + "4";
            };
            CINCO.Click += delegate {
                VALOR.Text = VALOR.Text + "5";
            };
            SEIS.Click += delegate {
                VALOR.Text = VALOR.Text + "6";
            };
            SIETE.Click += delegate {
                VALOR.Text = VALOR.Text + "7";
            };
            OCHO.Click += delegate {
                VALOR.Text = VALOR.Text + "8";
            };
            NUEVE.Click += delegate {
                VALOR.Text = VALOR.Text + "9";
            };
            CERO.Click += delegate {
                VALOR.Text = VALOR.Text + "0";
            };
            PUNTO.Click += delegate {
                VALOR.Text = VALOR.Text.IndexOf(".") == -1 ? (VALOR.Text + ".") : VALOR.Text;
            };

            CLOSE.Click += delegate{
                this.FinishAffinity();
            };

            C.Click += delegate{
                Valor1 = 0.0;
                Valor2 = 0.0;
                VALOR.Text = "";
            };
            CM.Click += delegate {
                Valor1 = 0.0;
                Valor2 = 0.0;
                Memoria = VALOR.Text.Length != 0 ? Convert.ToDouble(VALOR.Text) : 0.0;
                VALOR.Text = "";
            };
            M.Click += delegate {
                VALOR.Text = Convert.ToString(Memoria);
            };



            SUMA.Click              += delegate {
                PreparateStatementMathematica("+");
            };
            RESTA.Click             += delegate {
                PreparateStatementMathematica("-");
            };      
            DIVISION.Click          += delegate {
                PreparateStatementMathematica("/");
            };
            MULTIPLICACION.Click    += delegate {
                PreparateStatementMathematica("*");
            };

            IGUAL.Click             += delegate {
                if(operacion.Length != 0) {
                    this.Valor2 = Convert.ToDouble(VALOR.Text);
                    Double ValorDeArrastre = getValor();                   
                    VALOR.Text = Convert.ToString(ValorDeArrastre);
                }
            };
        }
        void PreparateStatementMathematica(string Operator) {
            this.Valor1         = VALOR.Text.Length != 0 ? Convert.ToDouble(VALOR.Text) : 0.0;
            VALOR.Text          = "";
            this.operacion      = Operator;
        }
        double getValor() {
            double ValorDeArrastre = 0.0;
            switch (this.operacion)
            {
                case "+":
                    ValorDeArrastre = this.Valor1 + this.Valor2;
                    break;
                case "-":
                    ValorDeArrastre = this.Valor1 - this.Valor2;
                    break;
                case "/":
                    ValorDeArrastre = this.Valor1 / this.Valor2;
                    break;
                case "*":
                    ValorDeArrastre = this.Valor1 * this.Valor2;
                    break;
            }
            return ValorDeArrastre;
        }
    }
}

