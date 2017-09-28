# SlugHub #
## Highly configurable URL slug generator, with persistent storage ##

SlugHub takes a string as an input, and converts it into URL friendly `slug`

For example:

	var slugGenerator = new SlugGenerator();
	var slug = slugGenerator.GenerateSlug("Some text that needs slugging ");
	Console.WriteLine(slug);

Outputs

> some-text-that-needs-slugging