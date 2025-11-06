// Advanced Matrix Operations

public class AdvancedMatrixOperations
{
    // Determinant calculation (for 2x2 and 3x3 matrices)
    public static double Determinant(Matrix matrix)
    {
        if (matrix.Rows != matrix.Columns)
            throw new ArgumentException("Matrix must be square");

        if (matrix.Rows == 1)
            return matrix[0, 0];
        
        if (matrix.Rows == 2)
            return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

        if (matrix.Rows == 3)
            return matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) -
                   matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0]) +
                   matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

        // For larger matrices, use recursive approach
        return DeterminantRecursive(matrix);
    }

    private static double DeterminantRecursive(Matrix matrix)
    {
        if (matrix.Rows == 1) return matrix[0, 0];
        
        double det = 0;
        for (int j = 0; j < matrix.Columns; j++)
        {
            det += Math.Pow(-1, j) * matrix[0, j] * DeterminantRecursive(GetMinor(matrix, 0, j));
        }
        return det;
    }

    private static Matrix GetMinor(Matrix matrix, int row, int col)
    {
        var minor = new Matrix(matrix.Rows - 1, matrix.Columns - 1);
        int m = 0, n = 0;
        
        for (int i = 0; i < matrix.Rows; i++)
        {
            if (i == row) continue;
            n = 0;
            for (int j = 0; j < matrix.Columns; j++)
            {
                if (j == col) continue;
                minor[m, n] = matrix[i, j];
                n++;
            }
            m++;
        }
        return minor;
    }

    // Matrix inverse using Gaussian elimination
    public static Matrix Inverse(Matrix matrix)
    {
        if (matrix.Rows != matrix.Columns)
            throw new ArgumentException("Matrix must be square");
        
        if (Math.Abs(Determinant(matrix)) < 1e-10)
            throw new ArgumentException("Matrix is singular, cannot invert");

        int n = matrix.Rows;
        var augmented = new Matrix(n, 2 * n);
        
        // Create augmented matrix [A|I]
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                augmented[i, j] = matrix[i, j];
            augmented[i, i + n] = 1.0;
        }

        // Gaussian elimination
        for (int i = 0; i < n; i++)
        {
            // Pivot
            double maxEl = Math.Abs(augmented[i, i]);
            int maxRow = i;
            for (int k = i + 1; k < n; k++)
            {
                if (Math.Abs(augmented[k, i]) > maxEl)
                {
                    maxEl = Math.Abs(augmented[k, i]);
                    maxRow = k;
                }
            }

            // Swap maximum row with current row
            for (int k = i; k < 2 * n; k++)
            {
                double temp = augmented[maxRow, k];
                augmented[maxRow, k] = augmented[i, k];
                augmented[i, k] = temp;
            }

            // Make all rows below this one 0 in current column
            for (int k = i + 1; k < n; k++)
            {
                double factor = -augmented[k, i] / augmented[i, i];
                for (int j = i; j < 2 * n; j++)
                {
                    if (i == j)
                        augmented[k, j] = 0;
                    else
                        augmented[k, j] += factor * augmented[i, j];
                }
            }
        }

        // Back substitution
        for (int i = n - 1; i >= 0; i--)
        {
            for (int k = n; k < 2 * n; k++)
                augmented[i, k] /= augmented[i, i];
            augmented[i, i] = 1.0;
            
            for (int row = 0; row < i; row++)
            {
                double factor = augmented[row, i];
                for (int j = n; j < 2 * n; j++)
                    augmented[row, j] -= factor * augmented[i, j];
            }
        }

        // Extract inverse matrix
        var inverse = new Matrix(n, n);
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                inverse[i, j] = augmented[i, j + n];
        
        return inverse;
    }
}
