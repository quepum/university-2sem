// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Homework2;

var trie = new Trie();
trie.Add("apple");
Console.Write(trie.Add("apple"));
trie.Add("element");
trie.Add("application");
Console.Write(trie.Contains("apple"));