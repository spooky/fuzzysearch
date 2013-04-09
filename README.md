A sample project to help experimenting with 'smart' search. Provides an implementation for [Levenshtein](http://en.wikipedia.org/wiki/Levenshtein_distance) distance, [Damerau–Levenshtein](http://en.wikipedia.org/wiki/Damerau%E2%80%93Levenshtein_distance) distance and [Longest Common Subsequence](http://en.wikipedia.org/wiki/Longest_common_subsequence_problem) length.

All implementations have a 'Prime' version and a 'Tweaked' version. All use dynamic programming, but differ in memory usage (tweaked versions allocate less memory).

The web project uses the [Longest Common Subsequence](http://en.wikipedia.org/wiki/Longest_common_subsequence_problem) length to fill in results for an autocomplete input.
This allows greater flexibility in the search term like:

* tolerates typos
* allows to type non-adjacent characters so 'tiae' will give 'this is an example' a high rank in the results

Released unter the [MIT license](http://opensource.org/licenses/MIT).
