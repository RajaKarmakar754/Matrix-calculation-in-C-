// Basic Matrix Operations

public class MatrixOperations
{
    // Matrix addition
    public static Matrix Add(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new ArgumentException("Matrices must have the same dimensions");

        var result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                result[i, j] = a[i, j] + b[i, j];
        return result;
    }

    // Matrix subtraction
    public static Matrix Subtract(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
            throw new ArgumentException("Matrices must have the same dimensions");

        var result = new Matrix(a.Rows, a.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < a.Columns; j++)
                result[i, j] = a[i, j] - b[i, j];
        return result;
    }

    // Scalar multiplication
    public static Matrix Multiply(double scalar, Matrix matrix)
    {
        var result = new Matrix(matrix.Rows, matrix.Columns);
        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Columns; j++)
                result[i, j] = scalar * matrix[i, j];
        return result;
    }

    // Matrix multiplication
    public static Matrix Multiply(Matrix a, Matrix b)
    {
        if (a.Columns != b.Rows)
            throw new ArgumentException("Number of columns in A must equal number of rows in B");

        var result = new Matrix(a.Rows, b.Columns);
        for (int i = 0; i < a.Rows; i++)
            for (int j = 0; j < b.Columns; j++)
                for (int k = 0; k < a.Columns; k++)
                    result[i, j] += a[i, k] * b[k, j];
        return result;
    }

    // Transpose
    public static Matrix Transpose(Matrix matrix)
    {
        var result = new Matrix(matrix.Columns, matrix.Rows);
        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Columns; j++)
                result[j, i] = matrix[i, j];
        return result;
    }
}
