// Email validation service (SRP, OCP)
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

public interface IEmailValidator
{
    bool IsValid(string email);
}

public class BasicEmailValidator : IEmailValidator
{
    public bool IsValid(string email) => email.Contains("@");
}

// Mail sender (SRP, DIP)
public interface IEmailSender
{
    void Send(MailMessage message);
}

public class SmtpEmailSender : IEmailSender
{
    private SmtpClient _smtpClient = new SmtpClient();
    public void Send(MailMessage message) => _smtpClient.Send(message);
}

// User service (uses dependencies)
public class UserService
{
    private readonly IEmailValidator _validator;
    private readonly IEmailSender _emailSender;

    public UserService(IEmailValidator validator, IEmailSender emailSender)
    {
        _validator = validator;
        _emailSender = emailSender;
    }

    public void Register(string email, string password)
    {
        if (!_validator.IsValid(email))
            throw new ValidationException("Email is not valid");

        var user = new User(email, password);

        _emailSender.Send(new MailMessage("mysite@nowhere.com", email)
        {
            Subject = "Hello Foo"
        });
    }
}


public interface IShape
{
    double GetArea();
}

public interface IThreeDimensionalShape : IShape
{
    double GetVolume();
}

// 2D Shapes
public class Rectangle : IShape
{
    public double Height { get; set; }
    public double Width { get; set; }

    public double GetArea() => Height * Width;
}

public class Circle : IShape
{
    public double Radius { get; set; }

    public double GetArea() => Math.PI * Radius * Radius;
}

// 3D Shape
public class Cube : IThreeDimensionalShape
{
    public double Side { get; set; }

    public double GetArea() => 6 * Side * Side;
    public double GetVolume() => Math.Pow(Side, 3);
}

// Calculators
public class AreaCalculator
{
    public double TotalArea(IEnumerable<IShape> shapes)
    {
        return shapes.Sum(shape => shape.GetArea());
    }
}

public class VolumeCalculator
{
    public double TotalVolume(IEnumerable<IThreeDimensionalShape> shapes)
    {
        return shapes.Sum(shape => shape.GetVolume());
    }
}

public interface IShape
{
    double GetArea();
}

public interface IThreeDimensionalShape : IShape
{
    double GetVolume();
}

// 2D Shapes
public class Rectangle : IShape
{
    public double Height { get; set; }
    public double Width { get; set; }

    public double GetArea() => Height * Width;
}

public class Circle : IShape
{
    public double Radius { get; set; }

    public double GetArea() => Math.PI * Radius * Radius;
}

// 3D Shape
public class Cube : IThreeDimensionalShape
{
    public double Side { get; set; }

    public double GetArea() => 6 * Side * Side;
    public double GetVolume() => Math.Pow(Side, 3);
}

// Calculators
public class AreaCalculator
{
    public double TotalArea(IEnumerable<IShape> shapes)
    {
        return shapes.Sum(shape => shape.GetArea());
    }
}

public class VolumeCalculator
{
    public double TotalVolume(IEnumerable<IThreeDimensionalShape> shapes)
    {
        return shapes.Sum(shape => shape.GetVolume());
    }
}
