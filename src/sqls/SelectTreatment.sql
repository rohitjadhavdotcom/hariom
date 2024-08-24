

select t.*,
ad."Id" as "DiseaseId",
ad."Name" as "DiseaseName",
am."Id" as "MedicineId",
am."Name" as "MedicineName",
am2."Id" as "MantrasId",
am2."Name" as "MantrasName",
ayt."Id" as "YogTherapyId",
ayt."YogopcharTherapy" as "YogopcharTherapy"
from public."AppTreatments" t
left join public."AppTreatmentDiseaseMaps" tdm on tdm."TreatmentId" = t."Id"
left join public."AppDiseases" ad on ad."Id" = tdm."DiseaseId"
left join public."AppTreatmentMedicineMaps" tmm on tmm."TreatmentId" = t."Id"
left join public."AppMedicines" am on am."Id" = tmm."MedicineId"
left join public."AppTreatmentMantraMaps" tmd on tmd."TreatmentId" = t."Id"
left join public."AppMantras" am2 on am2."Id" = tmd."MantraId"
left join public."AppTreatmentYogTherapyMaps" tytm on tytm."TreatmentId" = t."Id"
left join public."AppYogTherapies" ayt on ayt."Id" = tytm."YogTherapyId"

where t."Id" = @Id