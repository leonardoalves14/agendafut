CREATE PROCEDURE spsCargo  
AS  
BEGIN  
  SELECT Cargo_Id, Cargo_Desc
    FROM Cargo a
   ORDER BY a.Cargo_Desc
END