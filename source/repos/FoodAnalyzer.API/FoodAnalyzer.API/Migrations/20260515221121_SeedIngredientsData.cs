using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoodAnalyzer.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedIngredientsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Description", "Name", "RiskLevel" },
                values: new object[,]
                {
                    { 1, "Kan şekerini hızla yükseltir, obezite ve diyabet riskini artırır.", "Glikoz Şurubu", "Orta" },
                    { 2, "Lezzet artırıcıdır (MSG). Çarpıntı, baş ağrısı ve nörolojik hassasiyet yapabilir.", "Monosodyum Glutamat", "Kritik" },
                    { 3, "Koruyucu maddedir (E250). Özellikle işlenmiş etlerde bulunur, kanserojen potansiyeli vardır.", "Sodyum Nitrit", "Kritik" },
                    { 4, "Yapay tatlandırıcıdır. Uzun vadede sinir sistemi üzerinde olumsuz etkileri tartışılmaktadır.", "Aspartam", "Kritik" },
                    { 5, "Beyaz renklendiricidir (E171). Avrupa'da gıda takviyelerinde ve ürünlerinde kullanımı yasaklanmıştır.", "Titanyum Dioksit", "Kritik" },
                    { 6, "Sarı renklendiricidir (E102). Çocuklarda hiperaktiviteye ve alerjik reaksiyonlara neden olabilir.", "Tartrazin", "Kritik" },
                    { 7, "Kıvam artırıcıdır (E407). Sindirim sistemi rahatsızlıklarına ve bağırsak enflamasyonuna yol açabilir.", "Karragenan", "Orta" },
                    { 8, "Yüksek oranda doymuş yağ içerir. Kalp ve damar sağlığını olumsuz etkileyebilir.", "Palm Yağı", "Orta" },
                    { 9, "Karaciğer yağlanmasına ve insülin direncine yol açan oldukça tehlikeli bir tatlandırıcıdır.", "Yüksek Fruktozlu Mısır Şurubu", "Kritik" },
                    { 10, "Koruyucudur (E211). C vitamini ile birleştiğinde kanserojen olan benzene dönüşebilir.", "Sodyum Benzoat", "Orta" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
