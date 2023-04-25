package pl.retsuz.filesystem;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class TextFile extends GeneralComposite{
    String content;

    public String getContent() {
        return content;
    }

    public void setContent(String content) {
        this.content = content;
    }

    public String grep(String pattern)
    {
        String[] lines = this.content.split("\n");
        String result = "";
        for(String line:lines)
        {
            if(line.contains(pattern))
            {
                result += line + "\n";
            }
        }
        if(result =="") {
            return "Nie odnaleziono wzorca";
        }
        return result;
    }

    public String diff(IComposite textFile){
        List<String> leftLines = Arrays.asList(this.content.split("\n"));
        List<String> rightLines = Arrays.asList(((TextFile) textFile).content.split("\n"));
        List<String> diffLines = new ArrayList<>();

        // Use the LCS algorithm to find the common subsequence between the two lists of lines
        int m = leftLines.size();
        int n = rightLines.size();
        int[][] lcs = new int[m + 1][n + 1];
        for (int i = 0; i <= m; i++) {
            for (int j = 0; j <= n; j++) {
                if (i == 0 || j == 0) {
                    lcs[i][j] = 0;
                } else if (leftLines.get(i - 1).equals(rightLines.get(j - 1))) {
                    lcs[i][j] = lcs[i - 1][j - 1] + 1;
                } else {
                    lcs[i][j] = Math.max(lcs[i - 1][j], lcs[i][j - 1]);
                }
            }
        }

        // Use the LCS matrix to generate the diff output
        int i = m;
        int j = n;
        while (i > 0 && j > 0) {
            if (leftLines.get(i - 1).equals(rightLines.get(j - 1))) {
                // Lines are the same, add the line to the diff output
                diffLines.add(0, leftLines.get(i - 1));
                i--;
                j--;
            } else if (lcs[i - 1][j] > lcs[i][j - 1]) {
                // Line is only present in the left list, add a "-" prefix
                diffLines.add(0, "-" + leftLines.get(i - 1));
                i--;
            } else {
                // Line is only present in the right list, add a "+" prefix
                diffLines.add(0, "+" + rightLines.get(j - 1));
                j--;
            }
        }

        // Add any remaining lines from the left or right list
        while (i > 0) {
            diffLines.add(0, "-" + leftLines.get(i - 1));
            i--;
        }
        while (j > 0) {
            diffLines.add(0, "+" + rightLines.get(j - 1));
            j--;
        }

        return diffLines.toString();
    }
}
