// Time Complexity : O(n^2)
// Space Complexity : O(n)
// Did this code successfully run on Leetcode : No
// Any problem you faced while coding this : No


// Your code here along with comments explaining your approach
// 1) Start putting building in any lot
// 2) Calculate distance ofr evey cordinate from thet building


int H, W, N;
int minDistance;
public int BuildingPlacement(int h, int w, int n)
{
    this.H = h;
    W = w;
    N = n;
    minDistance = Int32.MaxValue;
    return ComputeDistance();
}

public int ComputeDistance()
{
    //place a building
    int[,] grid = new int[H, W];
    for (int i = 0; i < H; i++)
    {
        for (int j = 0; j < W; j++)
        {
            grid[i, j] = -1;
        }
    }
    //compute a farthest lot
    backtrackingBuildingPlacement(grid, N, 0, 0);

    return minDistance;
}

private void backtrackingBuildingPlacement(int[,] grid, int n, int r, int c)
{
    //base
    if(n == 0)
    {
        bfsBuildingPlacement(grid);
        return;
    }

    //logic
    //if we rached the last columnm go to next row and column 0
    if (c == W)
    {   
        r++;
        c = 0;
    }
    for (int i = r; i < H; i++)
    {
        for (int j = c; j < W; j++)
        {
            //action - place a building
            grid[i, j] = 0;
            //recursion - call other lots in recursive manner
            backtrackingBuildingPlacement(grid, n - 1, i, j + 1);
            //backtrack - change back to empty lot
            grid[i, j] = -1;
        }
    }
}

private void bfsBuildingPlacement(int[,] grid)
{
    bool[,] visited = new bool[H, W];
    Queue<int[]> queue = new Queue<int[]>();
    //look for builidng to put inside the queue
    for (int i = 0; i < H; i++)
    {
        for (int j = 0; j < W; j++)
        {
            //if it is building, add to queue and mark as visited
            if(grid[i,j] == 0)
            {
                queue.Enqueue(new int[] { i, j });
                visited[i, j] = true;
            }
        }
    }

    dirs = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
    int distance = 0;
    while(queue.Count > 0)
    {
        int size = queue.Count;
        for (int i = 0; i < size; i++)
        {
            int[] curr = queue.Dequeue();
            foreach (var dir in dirs)
            {
                int nr = curr[0] + dir[0];
                int nc = curr[1] + dir[1];
                if(nr >= 0 && nc >= 0 && nr < H && nc < W && grid[nr, nc] == -1 && visited[nr, nc] == false)
                {
                    visited[nr, nc] = true;
                    queue.Enqueue(new int[] { nr, nc });
                }
            }
        }
        distance++;
    }
    minDistance = Math.Min(minDistance, distance + 1);
}
}