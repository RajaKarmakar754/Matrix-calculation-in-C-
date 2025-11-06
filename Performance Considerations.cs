// Performance Considerations

public class OptimizedMatrixOperations
{
    // Parallel matrix multiplication
    public static Matrix MultiplyParallel(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
            throw new ArgumentException("Invalid matrix dimensions");

        var result = new Matrix(a.Rows, b.Columns);
        
        Parallel.For(0, a.Rows, i =>
        {
            for (int j = 0; j < b.Columns; j++)
            {
                double sum = 0;
                for (int k = 0; k < a.Columns; k++)
                    sum += a[i, k] * b[k, j];
                result[i, j] = sum;
            }
        });
        
        return result;
    }

    // Using SIMD for vector operations (requires System.Numerics)
    public static Matrix AddSIMD(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new ArgumentException("Matrices must have same dimensions");

        var result = new Matrix(a.Rows, a.Columns);
        
        // This is a simplified example - actual SIMD implementation
        // would use Vector<T> for hardware acceleration
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < a.Columns; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        
        return result;
    }
}
