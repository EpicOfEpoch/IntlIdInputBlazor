# IntlIdInputBlazor

**IntlIdInputBlazor** is a Blazor wrapper for the [IntlIdInput](https://github.com/EpicOfEpoch/intl-id-input) JavaScript library, which provides internationalized input formatting and validation for identification numbers. This component allows seamless integration of `IntlIdInput` into Blazor applications with minimal setup.

## Features

- Automatic formatting and validation of international ID numbers.
- Blazor-friendly component with two-way binding.
- Supports multiple countries and ID formats.
- Lightweight and easy to integrate.

## Installation

1. Install the NuGet package (if available) or add the project to your solution.
2. Ensure the `IntlIdInput` JavaScript library is included in your `wwwroot`:

```html
<script src="_content/IntlIdInputBlazor/intl-id-input.min.js"></script>
<link rel="stylesheet" href="_content/IntlIdInputBlazor/intl-id-input.css" />
```

## Usage

### Basic Usage

```razor
@using IntlIdInputBlazor

<IntlIdInput @bind-Value="UserId" Placeholder="Enter your ID" Country="US" />
```

## Parameters

| Option | Type  | Description |
|--------|------|---------|-------------|
| `Value` | string | Two-way bound property to hold the input value. |
| `Country` | string | ISO country code to determine formatting/validation. |
| `Placeholder` | string | Placeholder text for the input. |
| `OnValidChanged` | EventCallback<bool> | Triggered when the validity of the input changes. |

## Example

```razor
@page "/id-input"

@code {
    private string UserId { get; set; }
    private bool IsValid { get; set; }

    private void HandleValidityChanged(bool valid)
    {
        IsValid = valid;
    }
}

<IntlIdInput @bind-Value="UserId" Country="ZA" Placeholder="Enter South African ID" OnValidChanged="HandleValidityChanged" />

<p>Entered ID: @UserId</p>
<p>Valid: @IsValid</p>
```
