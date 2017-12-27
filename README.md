# SlugHub #
## Highly configurable URL slug generator, with persistent storage ##

SlugHub takes a string as an input, and converts it into URL friendly `slug`

For example:

	var slugGenerator = new SlugGenerator();
	var slug = slugGenerator.GenerateSlug("Some text that needs slugging");
	Console.WriteLine(slug);

Output:

> some-text-that-needs-slugging

### Generating unique slugs using iteration ###

Calling `GenerateSlug(input)` with text that's already been slugged once (*and therefore stored in the `SlugStore` - more on that later*) will trigger an **iteration**.  

Let's see an example:

	var slug1 = slugGenerator.GenerateSlug("My Title");
	var slug2 = slugGenerator.GenerateSlug("My Title");
	
	Console.WriteLine(slug1);
	Console.WriteLine(slug2);
	
The output here would be

>my-title  
>my-title-1

The iteration seed can be configured using `SlugGeneratorOptions` when creating an instance of `SlugGenerator`

	//start at 100
	var options = new SlugGeneratorOptions { IterationSeedValue = 100 };
	var slugGenerator = new SlugGenerator(options);

	var slug1 = slugGenerator.GenerateSlug("My Title");
	var slug2 = slugGenerator.GenerateSlug("My Title");
	
	Console.WriteLine(slug1);
	Console.WriteLine(slug2);

The output here would be

>my-title  
>my-title-100


### Generating unique slugs using "uniquifiers" ###

Uniquifiers are things that can create a unique version of your input.  
Imagine you want to create slugged titles for pizza shops.  
Now let's assume one is in London, one is in Leeds.
We can pass London and Leeds in as optional uniqueifier parameters, which will then be included, if the original slug is already taken:

	var slug1 = slugGenerator.GenerateSlug("Pizza Shop", "London");
	var slug2 = slugGenerator.GenerateSlug("Pizza Shop", "Leeds");
	
In this example, the 2 slugs generated would be:

> pizza-shop  
> pizza-shop-leeds

This is because pizza-shop initially did not exist, so it didn't need a uniqueifier.  
The second time it tried to generate pizza-shop, it existed, so used the uniqueifier.

## Storage ##

The default implementation of `ISlugStore` is a simple `InMemorySlugStore`  
Exactly as it sounds, this simply stores slugs in memory.  
They are not persisted outside of the application, and when the application exits, the stored slugs are lost.

If you want something more persistable, simply create one, implementing the lightweight `ISlugStore` interface:

    public interface ISlugStore
    {
        bool Exists(string slug);
        void Store(Slug slug);
    }
