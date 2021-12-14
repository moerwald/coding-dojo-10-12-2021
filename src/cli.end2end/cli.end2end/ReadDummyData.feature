Feature: ReadDummyData
	We want to start the program with specific args and check the ouput dumped on stdout

Scenario: Start the CLI program and check stdout for dummy entry
	Given A file with testdata
	When I start the CLI program with argument "ShowAll"
	Then the following text shall be dropped on stdout
		| Stdout                                        |
		| 1 Dummy False~NewLine~2 Dummy2 False~NewLine~ |