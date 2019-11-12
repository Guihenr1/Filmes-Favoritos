using System;
using Xunit;

namespace Api.DomainTest._Util {
    public static class Extension {
        public static void ComMensagem(this ArgumentException e, string mensagem) {
            if (mensagem == e.Message)
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
        }
    }
}
