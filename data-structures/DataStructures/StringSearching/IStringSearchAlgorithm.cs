using System.Collections.Generic;

namespace DataStructures.StringSearching
{
    /// <summary>
    ///     The IStringSearchAlgorithm defines the function, Search, which will be called to
    ///     find all of the matches of the search string (pattern) within the input(toSearch)
    ///     string.
    /// </summary>
    public interface IStringSearchAlgorithm
    {
        IEnumerable<ISearchMatch> Search(string toFind, string toSearch);
    }

    /// <summary>
    ///     The ISearchMatch interface defines the index and length of a search match in
    ///     the input string.
    /// </summary>
    public interface ISearchMatch
    {
        int Start { get; }
        int Length { get; }
    }
}