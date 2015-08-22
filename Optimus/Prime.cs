using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimus
{
    /// <summary>
    /// This class returns all the prime numbers discovered for a given upper limit
    /// </summary>
    class Prime
    {
        /// <summary>
        /// Prime may stop calculating once the upper limit is reached
        /// </summary>
        public UInt64 dividend { get; set; }

        /// <summary>
        /// Prime Constructor
        /// </summary>
        /// <param name="dividend">The number to be factored.</param>
        public Prime(UInt64 dividend)
        {
            this.dividend = dividend;
        }

    }

    /// <summary>
    /// A list of primes
    /// </summary>
    class PrimeList : List<UInt32>
    {
        private const int FIRST_PRIME = 2;  // Our first known Prime number
        private const int SECOND_PRIME = 3; // Our second known ODD prime number

        private UInt32 _index;
        private UInt32 _currentPrime;
        private List<UInt32> _primes = new List<UInt32>();

        public PrimeList()
        {
            //Add First & Second Prime Numbers to List
            _primes.Add(FIRST_PRIME);
            _primes.Add(SECOND_PRIME); // Having this prevents problems with algorithm as First Prime is our only even prime number.
        }

        /// <summary>
        /// Next will iterate over all known primes until exhausted and then increment by 2 thereafter
        /// </summary>
        /// <returns>return the next known prime</returns>
        //public UInt32 Next()
        //{
        //    if (_currentPrime == 0)
        //    {
        //        //Seed with 2 (First Prime)
        //        _index = 0;
        //        _currentPrime = FIRST_PRIME; //or _primes[_index]
        //    }
        //    // Iterate through each known prime.
        //    else if (_currentPrime >= _primes[_primes.Count - 1])
        //    {
        //        // We've count up to the last known prime.  Increments sequentially from here.
        //        // Example: 2,3,5,[7],8...
        //        _currentPrime = _currentPrime + 2; // Increment by 2 to exclude even numbers (Primes are always odd, except 2)

        //        //TODO Test until prime
                
        //    }
        //    // These we've already identified as prime number and have added to our _primes list
        //    else
        //    {
        //        // Grab the next prime saved in our list...
        //        _index += 1;
        //        _currentPrime = _primes[_index];
        //    }
        //    return _currentPrime;
        //}

        /// <summary>
        /// Tests to determine if value is prime.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        //private bool isPrime(UInt32 value)
        //{
        //    if (value == FIRST_PRIME) return true; // Eliminate 2.  May pull out to reduce cycle time.
        //    if (value == SECOND_PRIME) return true; // Eliminate 3.  May pull out to reduce cycle time.
        //    if ((value & 1) == 0) return false; // Eliminate even numbers.
        //    if ((value % 5) == 0) return false; // Eliminate 5s

        //    foreach (uint prime in _primes)
        //    {
        //        while ((value % prime) == 0) || value == 0) 
        //        {
        //            _primes.Add(prime);
        //            value = value / prime;
        //        }
        //        if (value == 0) return false;
        //    }
        //    return true;
        //}


        private void GeneratePrimeFactors(ulong value)
        {
            ulong number = value;
            for (ulong i = 2; i <= number;)
            {
                while ((number % i) == 0) 
                {
                    Console.WriteLine("{0} / {1} = {2}", number, i, (number / i));
                    number = number / i;
                };
                i = (i == 2) ? i + 1 : i + 2;
            }
        }

        //private void BuildPrimeList(ulong value)
        //{
        //    uint upperlimit = (uint)Math.Sqrt((double)value);
            
        //    _primes.Add(FIRST_PRIME); 
            
        //    for (uint testvalue = FIRST_PRIME + 1; testvalue <= upperlimit; upperlimit+2)
        //    {
        //        foreach (uint prime in _primes)
        //        {
        //            if ((testvalue % prime) != 0) 
        //                isPrime = false;
        //            else
        //        }
                
        //    }
        //}

        //private bool isPrime2(uint value)
        //{
        //    if (value == FIRST_PRIME) return true; // Eliminate 2.  May pull out to reduce cycle time.
        //    if (value == SECOND_PRIME) return true; // Eliminate 3.  May pull out to reduce cycle time.
        //    if ((value & 1) == 0) return false; // Eliminate even numbers.
        //    if ((value % 5) == 0) return false; // Eliminate 5s

        //    uint testToMax = (uint)Math.Sqrt((double)value);

        //    //foreach (uint prime in _primes)
        //    for (uint i = FIRST_PRIME; i <= testToMax; i++)
        //    {
        //        if ((value % i) == 0) continue;
                




        //        while ((value % prime) == 0) || value == 0) 
        //        {
        //            _primes.Add(prime);
        //            value = value / prime;
        //        }
        //        if (value == 0) return false;
        //    }
        //    return true;
        //}
        
        //public List<uint> BuildPrimeFactorsList(uint value)
        //{
        //    List<uint> primeFactors = new List<uint>()
        //    foreach (uint prime in _primes)
        //    {
        //        while ((value % prime) == 0) || value == 0) 
        //        {
        //            primeFactors.Add(prime);
        //            value = value / prime;
        //        }
        //        if (value == 0) break;
        //    }
        //    // Outcomes from above:
        //    //      - all known primes exhausted and value did NOT reduce to 0
        //    //      - all known primes exhausted and value did reduce to 0

        //    // Start with last prime and test primality of each odd number up to adjusted value.
        //    // Note if we did not have SECOND_PRIME defined this would produce all even numbers!
        //    for (uint testPrime = _primes.Last() + 2; testPrime <= (uint)Math.Sqrt((double)value); testPrime + 2;)
        //    {
        //        if (
        //    }

        //    if (value != 0 )
        //    {
        //        // Test if new value is prime
        //        // This number should be odd
        //        // Either prime, or a number between it and our primes list is prime

        //        // This last number must be prime?
        //        primeFactors.Add(value);
        //        _primes.Add(value);
        //    }
        //    return primeFactors;
        //}
    }
}
