﻿using System;
using Microsoft.Speech.Recognition;
using System.Threading.Tasks;
using System.Threading;

namespace Speach
{
    static class Speech
    {
        static SpeechRecognitionEngine mSpech;

        static CancellationTokenSource srcToken = new CancellationTokenSource();
        static CancellationToken token = srcToken.Token;
        static Task th;

        public delegate void DetectedEventHandler(DetectedEventArgs e);
        static public event DetectedEventHandler WordsDetected;

        static public void Inicil()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("ru-ru"));
            rec.SetInputToDefaultAudioDevice();
            
            Choices comm = new Choices();
            Choices bort = new Choices();
            comm.Add(new string[] { "навигация","системы","ход семьдесят пять" , "ход двадцать пять", "ход пятьдесят", "полный ход", "буст", "карта галактики" , "карта системы" ,"свет","стоп","связь","функции","прыжок","оружие","назад","шасси","теплоотвод","цель","враг"});
            bort.Add(new string[] { "борт" });

            GrammarBuilder gram = new GrammarBuilder();
            gram.Append(bort);
            gram.Append(comm);

            Grammar gr = new Grammar(gram);

            rec.LoadGrammar(gr);
            rec.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec_SpeechRecognized);
            mSpech = rec;

            th = Task.Factory.StartNew(TryRec,token);
        }

        static void TryRec()
        {
            while(true)
            {
                RecognitionResult recrez = mSpech.Recognize();
            }
        }

        static void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result.Confidence >= 0.9)
                WordsDetected(new DetectedEventArgs(e.Result.Text));
        }

        static void StopTasks()
        {
            if (th != null)
                srcToken.Cancel();
        }
    }

    public class DetectedEventArgs : EventArgs
    {
        public DetectedEventArgs(string words)
        {
            mess = words;
        }

        private string mess;

        public string Detected
        {
            get { return mess; }
        }
    }


}
