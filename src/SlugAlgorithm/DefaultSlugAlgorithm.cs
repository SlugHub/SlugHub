using System.Text.RegularExpressions;

namespace SlugHub.SlugAlgorithm
{
    public class DefaultSlugAlgorithm : ISlugAlgorithm
    {
        private readonly SlugAlgorithmOptions _defaultOptions;

        public DefaultSlugAlgorithm()
        {
            _defaultOptions = new SlugAlgorithmOptions
            (
                //lowercase the whole string
                str => str.ToLower(),

                //remove diacritics
                str =>
                {
                    var bytes = System.Text.Encoding.GetEncoding("ISO-8859-8")
                        .GetBytes(str);

                    return System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                },

                // invalid chars           
                str => Regex.Replace(str, @"[^a-z0-9\s-]", ""),

                // convert multiple spaces into one space   
                str => Regex.Replace(str, @"\s+", " ").Trim(),

                // hyphens   
                str => Regex.Replace(str, @"\s", "-")
            );
        }

        public string Slug(string phrase)
        {
            return Slug(phrase, _defaultOptions);
        }

        public string Slug(string phrase, SlugAlgorithmOptions options)
        {
            var result = phrase;

            foreach (var manipulator in options.Manipulators)
                result = manipulator(result);

            return result;
        }
    }
}