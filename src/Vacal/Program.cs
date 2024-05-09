using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using Microsoft.CognitiveServices.Speech.Translation;
using Microsoft.Extensions.Configuration;

namespace Vacal
{
    class Program
    {
        public static string _subscriptionKey;
        public static string _region;
        public static IConfiguration _configuration;

        static async Task Main(string[] args)
        {
            _configuration = new ConfigurationBuilder()
                                    .AddJsonFile($"appsettings.json")
                                    .Build();

            _subscriptionKey = _configuration["SubscriptionKey"];
            _region = _configuration["Region"];

            await SpeechToText();
            //await SpeechToTranslate();

            Console.WriteLine("Pressione uma tecla para finalizar o terminal!");
        }

        static async Task SpeechToTranslate()
        {
            Console.WriteLine("Fale Algo");
            var speechConfig = SpeechTranslationConfig.FromSubscription(
                _subscriptionKey,
                _region);

            speechConfig.SpeechRecognitionLanguage = "pt-BR";

            //speechConfig.AddTargetLanguage("en-US");
            var langs = new List<string> { "en-US", "fr-FR", "it-IT" };
            langs.ForEach(speechConfig.AddTargetLanguage);

            var recognizer = new TranslationRecognizer(speechConfig);
            var result = await recognizer.RecognizeOnceAsync();

            if (result.Reason == ResultReason.TranslatedSpeech)
            {
                Console.WriteLine(result.Text);

                foreach (var lang in result.Translations)
                {
                    Console.WriteLine($"{lang.Key} - {lang.Value}");
                }
            }

            Console.ReadLine();
        }

        static async Task SpeechToText()
        {
            var speechConfig = SpeechConfig.FromSubscription(_subscriptionKey, _region);
            var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            var recognizer = new SpeechRecognizer(speechConfig, "pt-BR", audioConfig);

            Console.WriteLine("Fale alguma coisa:");

            string texto = string.Empty;
            do
            {
                var result = await recognizer.RecognizeOnceAsync();
                texto = result.Text;

                Console.WriteLine($"Reconhecido: {texto} ");

            } while (!texto.ToLower().Contains("sair"));

            Console.ReadLine();
        }
    }
}
