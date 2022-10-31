Create Procedure spDeleteMessage
@id int
as
Begin
  Delete from iletisim where id = @id
End