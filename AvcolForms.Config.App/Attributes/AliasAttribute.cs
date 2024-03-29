﻿/*
 * Licensed under the MIT License
 * Copyright (c) 2022 Bradley Grover
 */

namespace AvcolForms.Config.App.Attributes;

/// <summary>
/// Alias attribute, provides aliases for <see cref="CommandAttribute"/> so that they can be used for the same command
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class AliasAttribute : Attribute
{
    /// <summary>
    /// String array of trhe aliases that can be used
    /// </summary>
    public string[] Aliases { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AliasAttribute"/> class
    /// </summary>
    /// <param name="aliases">Arbitrary amount of aliases to be used</param>
    public AliasAttribute(params string[] aliases)
    {
        ArgumentNullException.ThrowIfNull(aliases, nameof(aliases));

        Aliases = aliases;
    }
}
