////------------------------------------------------------------------------
////<copyright file="BirdAdapter.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace DesignPattern.StructuralDesignPatterns.BirdAdapter
{
    /// <summary>
    /// Bird Adapter
    /// </summary>
    /// <seealso cref="DesignPattern.StructuralDesignPatterns.BirdAdapter.IBird" />
    class BirdAdapter : IBird
    {
        /// <summary>
        /// The plastic bird
        /// </summary>
        private PlasticBird plasticBird;

        /// <summary>
        /// Initializes a new instance of the <see cref="BirdAdapter"/> class.
        /// </summary>
        /// <param name="bird">The bird.</param>
        public BirdAdapter(PlasticBird bird)
        {
            this.plasticBird = bird;
        }

        /// <summary>
        /// Makes the sound.
        /// </summary>
        public void MakeSound()
        {
            this.plasticBird.Speak();
        }
    }
}
