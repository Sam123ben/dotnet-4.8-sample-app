# Simple Calculator

A lightweight, user-friendly calculator application built with .NET Framework 4.8 and Windows Forms.

## Features

- **Basic Arithmetic**: Addition, subtraction, multiplication, and division
- **Additional Functions**: Percentage calculations, sign toggle, decimal support
- **Clean Interface**: Modern, intuitive design with color-coded buttons
- **Error Handling**: Graceful handling of division by zero and other errors
- **Keyboard-like Layout**: Familiar calculator button arrangement

## Screenshots

The calculator features a clean interface with:
- Large display area for numbers and results
- Color-coded buttons (orange for operations, gray for functions, white for numbers)
- Standard calculator layout for intuitive use

## System Requirements

- Windows 7 or later
- .NET Framework 4.8 or later

## Installation

1. Download the latest release from the [Releases](../../releases) page
2. Extract the ZIP file to your desired location
3. Run `SimpleCalculator.exe`

No installation required - it's a portable application!

## Development

### Prerequisites

- Visual Studio 2019 or later (with .NET Framework 4.8 development tools)
- Windows SDK

### Building from Source

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/simple-calculator.git
   cd simple-calculator
   ```

2. Open in Visual Studio or build from command line:
   ```bash
   msbuild SimpleCalculator.csproj /p:Configuration=Release
   ```

3. The executable will be in `bin\Release\SimpleCalculator.exe`

### Project Structure

```
SimpleCalculatorApp/
├── Program.cs              # Application entry point
├── CalculatorForm.cs       # Main calculator form and logic
├── SimpleCalculator.csproj # Project file
├── App.config             # Application configuration
├── Properties/
│   └── AssemblyInfo.cs    # Assembly metadata
└── .github/
    └── workflows/
        └── build-and-package.yml # GitHub Actions workflow
```

## GitHub Actions Workflow

This project includes a comprehensive GitHub Actions workflow that:

- **Builds** the application using MSBuild
- **Tests** the build output to ensure success
- **Packages** the application into a ZIP file
- **Creates releases** automatically when tags are pushed
- **Uploads artifacts** for easy download
- **Publishes packages** to GitHub Packages

### Triggering Builds

- **Push to main/develop**: Creates build artifacts
- **Pull requests**: Validates the build
- **Tags (v*)**: Creates a full release with downloadable packages

### Creating a Release

To create a new release:

1. Tag your commit:
   ```bash
   git tag v1.0.1
   git push origin v1.0.1
   ```

2. The workflow will automatically:
   - Build the application
   - Create a GitHub Release
   - Upload the packaged ZIP file
   - Publish to GitHub Packages

## Usage

The calculator supports standard operations:

- **Numbers**: Click 0-9 to input numbers
- **Operations**: +, -, ×, ÷ for basic arithmetic
- **Functions**:
  - `C`: Clear all
  - `±`: Toggle positive/negative
  - `%`: Convert to percentage
  - `.`: Add decimal point
  - `=`: Calculate result

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## License

This project is open source and available under the MIT License.

## Support

If you encounter any issues or have suggestions for improvements, please:

1. Check the [Issues](../../issues) page for existing reports
2. Create a new issue with detailed information about the problem
3. Include your Windows version and .NET Framework version

## Changelog

### v1.0.0
- Initial release
- Basic calculator functionality
- Windows Forms interface
- GitHub Actions CI/CD pipeline