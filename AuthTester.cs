using System;
using Security;

namespace TestAuthMacOSNET6
{
	public static class AuthTester
	{
		public static void RunTest ()
		{
			var fileName = "/usr/local/share/dotnet/dotnet";
			var args = new[] { "--help" };

			var parameters = new AuthorizationParameters {
				Prompt = "Test Auth",
				PathToSystemPrivilegeTool = "" // Cannot be null otherwise the prompt is not displayed.
			};

			var flags = AuthorizationFlags.ExtendRights |
				AuthorizationFlags.InteractionAllowed |
				AuthorizationFlags.PreAuthorize;

			using (var auth = Authorization.Create (parameters, null, flags)) {
				int result = auth.ExecuteWithPrivileges (
					fileName,
					AuthorizationFlags.Defaults,
					args);

				if (result != 0) {
					if (Enum.TryParse (result.ToString (), out AuthorizationStatus authStatus)) {
						if (authStatus == AuthorizationStatus.Canceled) {
							return;
						} else if (authStatus == AuthorizationStatus.ToolExecuteFailure) {
							// Reaches here. -60031
							// https://developer.apple.com/documentation/security/1540004-authorization_services_result_co/errauthorizationtoolexecutefailure
							throw new InvalidOperationException ($"Could not get authorization. {authStatus}");
						} else {
							throw new InvalidOperationException ($"Could not get authorization. {authStatus}");
						}
					}
					throw new InvalidOperationException ($"Could not get authorization. {result}");
				}
			}
		}
	}
}

