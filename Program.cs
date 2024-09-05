//*****************************************************************************
//** 2028. Find Missing Observation  leetcode                                **
//*****************************************************************************


int* missingRolls(int* rolls, int rollsSize, int mean, int n, int* returnSize)
{
    int totesMyGoats = 0;
    
    // Calculate the total sum of the observed rolls
    for(int i = 0; i < rollsSize; i++)
    {
        totesMyGoats += rolls[i];
    }

    // Calculate the target sum of all n + rollsSize observations
    int totalNumerator = mean * (rollsSize + n);
    
    // Calculate the missing sum we need to fill with missing rolls
    int missingSum = totalNumerator - totesMyGoats;

    // Validate if it's possible to have a valid solution
    if(missingSum < n || missingSum > 6 * n)
    {
        *returnSize = 0;
        return NULL;  // No valid solution
    }
    
   // Allocate memory for the result array
    int* result = (int*)malloc(n * sizeof(int));
    *returnSize = n;

    // Distribute the missing sum evenly across the rolls
    int baseValue = missingSum / n;  // Base value for all rolls
    int remainder = missingSum % n;  // Remainder to distribute

    for(int i = 0; i < n; i++)
    {
        result[i] = baseValue;
        if (i < remainder)  // Distribute the remainder by adding 1 to some rolls
        {
            result[i]++;
        }
    }

    return result;
}