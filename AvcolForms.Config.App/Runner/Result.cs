﻿/*
 * Licensed under the MIT License
 * Copyright (c) 2022 Bradley Grover
 */

namespace AvcolForms.Config.App.Runner;

/// <summary>
/// Result type of executing the command
/// </summary>
public enum Result
{
    /// <summary>
    /// The runner found no command
    /// </summary>
    NotFound,
    /// <summary>
    /// The runner successfully ran the command
    /// </summary>
    Success,
    /// <summary>
    /// The runner found the command, but the params were incorrect
    /// </summary>
    Mismatch,
    /// <summary>
    /// Execution of the command ran into an erro
    /// </summary>
    Error
}
