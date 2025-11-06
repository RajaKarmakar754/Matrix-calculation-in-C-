public class Matrix
{
    private double[,] data;
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public Matrix(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        data = new double[rows, columns];
    }

    public double this[int row, int col]
    {
        get => data[row, col];
        set => data[row, col] = value;
    }

    // Create matrix from 2D array
    public static Matrix FromArray(double[,] array)
    {
        var matrix = new Matrix(array.GetLength(0), array.GetLength(1));
        for (int i = 0; i < matrix.Rows; i++)
            for (int j = 0; j < matrix.Columns; j++)
                matrix[i, j] = array[i, j];
        return matrix;
    }

    // Create identity matrix
    public static Matrix Identity(int size)
    {
        var matrix = new Matrix(size, size);
        for (int i = 0; i < size; i++)
            matrix[i, i] = 1.0;
        return matrix;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
                sb.Append($"{data[i, j]:F2}\t");
            sb.AppendLine();
        }
        return sb.ToString();
    }
}
