using AutoMapper;

namespace Tool.Framework.Derivation
{
    public class DataCalculationMemberValueResolver<TSource, TDest> : IMemberValueResolver<TSource, TDest, int, int>
    {
        public int Resolve(TSource source, TDest destination, int sourceMember, int destMember, ResolutionContext context)
            => sourceMember + destMember;
    }
}
