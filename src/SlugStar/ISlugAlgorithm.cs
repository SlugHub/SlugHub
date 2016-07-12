﻿namespace SlugStar
{
    public interface ISlugAlgorithm
    {
        string Slug(string phrase);

        string Slug(string phrase, SlugAlgorithmOptions options);
    }
}