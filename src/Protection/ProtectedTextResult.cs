namespace Furryfier.Protection;

public record ProtectedTextResult(string ProtectedText, List<ProtectedPart> ProtectedParts);

public record ProtectedPart(string Placeholder, string Original);