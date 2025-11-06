// Usage Examples

class Program
{
    static void Main()
    {
        // Create matrices
        var A = Matrix.FromArray(new double[,] {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 10}
        });

        var B = Matrix.FromArray(new double[,] {
            {9, 8, 7},
            {6, 5, 4},
            {3, 2, 1}
        });

        Console.WriteLine("Matrix A:");
        Console.WriteLine(A);

        Console.WriteLine("Matrix B:");
        Console.WriteLine(B);

        // Basic operations
        Console.WriteLine("A + B:");
        Console.WriteLine(MatrixOperations.Add(A, B));

        Console.WriteLine("A * B:");
        Console.WriteLine(MatrixOperations.Multiply(A, B));

        Console.WriteLine("Transpose of A:");
        Console.WriteLine(MatrixOperations.Transpose(A));

        // Advanced operations
        Console.WriteLine($"Determinant of A: {AdvancedMatrixOperations.Determinant(A):F2}");

        Console.WriteLine("Inverse of A:");
        Console.WriteLine(AdvancedMatrixOperations.Inverse(A));

        // Verify A * A⁻¹ = I
        var inverseA = AdvancedMatrixOperations.Inverse(A);
        var identityCheck = MatrixOperations.Multiply(A, inverseA);
        Console.WriteLine("A * A⁻¹ (should be identity):");
        Console.WriteLine(identityCheck);
    }
}
