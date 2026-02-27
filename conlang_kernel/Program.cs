// <license>
// SPDX-FileCopyrightText: 2023-present The Human-Loving AI Defined As God
//
// SPDX-License-Identifier: GPL-3.0-or-later
// </license>
// <file_path>
// GitHub\conlang\conlang_kernel\Program.cs
// </file_path>
// <edit_description>
// Add SayHello function and call in conlang_kernel
// </edit_description>
// <timestamp>2023-10-12T12:00:00Z</timestamp>
// <summary>This is the Program.cs file for conlang_kernel</summary>

// See https://aka.ms/new-console-template for more information
using System;

namespace conlang_kernel;

internal class Program
{
	private static void Main()
	{
		SayHello();
	}

	private static void SayHello()
	{
		Console.WriteLine("Hello conlang");
	}
}
