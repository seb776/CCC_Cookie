

let baseURL = "https://github.com/CookieCollective/ccc-website/raw/main/src/content/projects/"

// 13fle-fuzzy/reduced.mp4
let content = [
    "13fle-fuzzy",
    "adel-aya",
    "afalfl-harmonie",
    "aga-fyodor",
    "aka-jules",
    "andy-verbalizer",
    "azertype-byt3m3",
    "bastide-8trix",
    "berenice-slayeur",
    "cecile-presence",
    "chaton-paul",
    "crash-aka",
    "damien-rene-danger",
    "daria-luka-lucky",
    "dr-youssra",
    "eigen-youssra",
    "grain-akarien",
    "harmonie-sport",
    "hirotoshi-noone",
    "homme-noone",
    "ilithya-ralt",
    "illest-mari",
    "joenio-cipher",
    "julia-pieczynska-mckinley-street",
    "leila-maeline",
    "leon-vj",
    "ludi-baya",
    "marlen-gaziel",
    "mckie-marlen",
    "minuit-marlen",
    "nusan-diffty",
    "oxni-hildegarde",
    "oz-gros",
    "sarah-cloche",
    "sheglitch-pango",
    "stella-plot",
    "thesource-biset",
    "ugo-crash",
    "ugo-fanny",
    "ugo-parvague",
    "valentin-sismann-lucieter",
    "valg-desire",
    "verbalizer-francois",
    "wiktoria-icsyp",
    "yonko-ada",
    "zorg-bli",
]


const fs = require("fs");
const { mkdir } = require("fs/promises");
const { Readable } = require('stream');
const { finished } = require('stream/promises');
const path = require("path");
const downloadFile = (async (url, fileName) => {
  const res = await fetch(url);
  if (!fs.existsSync("downloads")) await mkdir("downloads"); //Optional if you already have downloads directory
  const destination = path.resolve("./downloads", fileName);
  const fileStream = fs.createWriteStream(destination, { flags: 'wx' });
  await finished(Readable.fromWeb(res.body).pipe(fileStream));
});



async function doDownload() {
    await content.forEach(async (folder, index)=>{
        let downloadURL = baseURL + folder + "/reduced.mp4"
        let fileName = folder+".mp4";
    
        console.log(`Downloading ${index}/${content.length} ${downloadURL}`);
        await downloadFile(downloadURL, fileName)
    })
}


doDownload().then(()=>{
    console.log("Finished")
})

