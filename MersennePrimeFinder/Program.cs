using System;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;
using System.Globalization;

namespace MersennePrimeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<BigInteger> passes = new List<BigInteger>();
            int n = 2;

            while (true)
            {
                Program.GenerateCandidates(n, passes);
                n++;
            }
        }
        static void GenerateCandidates(int n, List<BigInteger> p)
        {
            BigInteger candidate = (BigInteger)(Math.Pow(2, n) - 1);

            if (Program.CandidateCheck(candidate))
            {
                Program.AddPassedCandidate(candidate, p);
                Program.PrintAllCandidates(p);
            }
            else
            {
                return;
            }
        }
        static bool CandidateCheck(BigInteger c)
        {
            // Divides candidate by numbers 1 to itself; if a whole number factor besides 1 or candidate isn't found, then the candidate is a Mersenne prime
            for (BigInteger i = 1; i <= c; i++)
            {
                BigInteger factor = BigInteger.DivRem(c, i, out BigInteger rem);

                // Checks if remainder of division is zero; if so, the factor is a whole number; if not, continue
                if (rem.Equals(BigInteger.Zero))
                {
                    // Checks if factor is not equal to numbers 1 or itself; if so, the candidate is not a Mersenne prime; if not, continue
                    if (!(factor.Equals(BigInteger.One) || factor.Equals(c)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        static void AddPassedCandidate(BigInteger c, List<BigInteger> p)
        {
            p.Add(c);
        }
        static void PrintAllCandidates(List<BigInteger> p)
        {
            Console.Clear();

            Console.WriteLine("Finding Mersenne primes...");
            Console.WriteLine("Current # of Mersenne primes found: " + p.Count);

            for (int i = 0; i < p.Count; i++)
            {
                Console.WriteLine(p[i].ToString());
            }
        }
    }
}