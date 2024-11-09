using System;
using System.Collections.Generic;

namespace Aegiss.Models;

/// <summary>
/// Tabela que armazena os dados do usuário da aplicação.
/// </summary>
public partial class AppUser
{
    public long Id { get; set; }

    /// <summary>
    /// Username para acesso à aplicação.
    /// </summary>
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    /// <summary>
    /// E-mail do usuário da aplicação.
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// Nome do usuário da aplicação.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Número de telefone do usuário aplicação.
    /// </summary>
    public string PhoneNumber { get; set; } = null!;

    /// <summary>
    /// Data de nascimento do usuário da aplicação.
    /// </summary>
    public DateOnly? DateOfBirth { get; set; }

    /// <summary>
    /// Cep do endereço do usuário da aplicação.
    /// </summary>
    public string? ZipCode { get; set; }

    /// <summary>
    /// Rua do endereço do usuário da aplicação.
    /// </summary>
    public string? StreetName { get; set; }

    /// <summary>
    /// Número da rua do endereço do usuário da aplicação.
    /// </summary>
    public string? StreetNumber { get; set; }

    /// <summary>
    /// Bairro do endereço do usuário da aplicação.
    /// </summary>
    public string? Neighborhood { get; set; }

    /// <summary>
    /// Cidade do endereço do usuário da aplicação.
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Estado do endereço do usuário da aplicação.
    /// </summary>
    public string? State { get; set; }

    public DateTime? LastUsernameDateChange { get; set; }

    public string? RefreshToken { get; set; } = null;

    /// <summary>
    /// Data de criação do usuário da aplicação.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public virtual ICollection<EmailReset> EmailResets { get; set; } = new List<EmailReset>();

    public virtual ICollection<LocationAccess> LocationAccesses { get; set; } = new List<LocationAccess>();

    public virtual ICollection<PasswordReset> PasswordResets { get; set; } = new List<PasswordReset>();

    public virtual ICollection<UserCharacteristic> UserCharacteristics { get; set; } = new List<UserCharacteristic>();
}
