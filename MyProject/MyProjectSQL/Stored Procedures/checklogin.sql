CREATE PROCEDURE CheckLogin(
	@user_email NVARCHAR(500),
	@user_pass NVARCHAR(500)
)
as
begin
	SET NOCOUNT ON;
	select Email, Password from UserDetails where Email = @user_email and Password = @user_pass
end