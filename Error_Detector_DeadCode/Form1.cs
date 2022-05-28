using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;

using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using WindowsFormsApp3;

namespace Error_Detector_DeadCode;

public class Form1 : Form
{
	private IContainer components;

	private Label LabelJavaInfo;

	private Label JavaError;

	private Label resetoptions;

	private Label setjavalabel;

	private Label connectionlabel;

	private ProgressBar BarValue;

	private Label LabelI;

	private Label minepathe;

	private FolderBrowserDialog folderBrowserDialog1;

	private Label labelpath;

	private Label DelayLabel;

	private Label LabelServer;

	private Label datewinlabel;

	private CastomButton pathbtn;

	private CastomButton checker;

	private CastomButton trash;

	private Label ILOL;

	public Form1()
	{
		InitializeComponent();
		BarValue.ForeColor = Color.Green;
		BarValue.BackColor = Color.FromArgb(62, 52, 52);
	}

	private async void Form1_Load(object sender, EventArgs e)
	{
		ToolTip toolTip = new ToolTip();
		toolTip.BackColor = Color.Black;
		toolTip.ForeColor = Color.Brown;
		toolTip.SetToolTip(LabelI, "Try_Parse#1645");
		toolTip.SetToolTip(pathbtn, "Выбери папку .minecraft");
		toolTip.SetToolTip(checker, "Нажми что бы найти проблему и пофиксить её");
		labelpath.Text = GetDataPath("\\.minecraft");
		LabelJavaInfo.Cursor = Cursors.Hand;
		JavaError.Cursor = Cursors.Hand;
		while (true)
		{
			await Task.Delay(1000);
			if (!Directory.Exists(labelpath.Text))
			{
				labelpath.ForeColor = Color.Red;
			}
			else
			{
				labelpath.ForeColor = Color.Green;
			}
		}
	}

	public void JavaDetector()
	{
		for (int i = 241; i <= 321; i++)
		{
			if (File.Exists($"C:\\Program Files\\Java\\jre1.8.0_{i}\\bin\\javaw.exe"))
			{
				LabelJavaInfo.ForeColor = Color.Green;
				LabelJavaInfo.Text = $"Установленая джава: {i} ☑";
			}
		}
		if (LabelJavaInfo.Text == "")
		{
			LabelJavaInfo.ForeColor = Color.Red;
			LabelJavaInfo.Text = "Джава не установлена, нажми что бы установить X";
		}
	}

	public void LauncherDetector()
	{
		if (File.Exists(GetDataPath("\\.tlauncher\\legacy.properties")))
		{
			JavaError.ForeColor = Color.Green;
			JavaError.Text = "TLegacy установлен ☑";
		}
		else
		{
			JavaError.ForeColor = Color.Red;
			JavaError.Text = "TLegacy не установлен, нажми что бы установить X";
		}
	}

	public string GetDataPath(string childpath)
	{
		return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + childpath;
	}

	public async void SetOptionsLauncher()
	{
		resetoptions.ForeColor = Color.Red;
		try
		{
			string path = labelpath.Text + "\\optionsof.txt";
			if (File.Exists(path))
			{
				string[] array = File.ReadAllLines(path);
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == "ofFastRender:true")
					{
						array[i] = "ofFastRender:false";
						File.WriteAllLines(path, array);
					}
				}
				resetoptions.Text = "Выключаем быстрый рендер...";
			}
			else
			{
				resetoptions.Text = "Не найден файл 'optionsof.txt' X";
			}
			await Task.Delay(500);
			string path2 = labelpath.Text + "\\options.txt";
			if (File.Exists(path2))
			{
				string[] array2 = File.ReadAllLines(path2);
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] == "fancyGraphics:false")
					{
						array2[j] = "fancyGraphics:true";
						File.WriteAllLines(path2, array2);
					}
				}
				resetoptions.Text = "Настраиваем графику..";
				await Task.Delay(500);
				resetoptions.ForeColor = Color.Green;
				resetoptions.Text = "Графика настроена! ☑";
			}
			else
			{
				resetoptions.Text = "Не найден файл 'options.txt' X";
			}
		}
		catch (Exception)
		{
			resetoptions.Text = "Не удалось настроить майнкрафт X";
		}
	}

	public async void setcustomjava()
	{
		try
		{
			setjavalabel.ForeColor = Color.Red;
			setjavalabel.Text = "Закрывем процессы...";
			await Task.Delay(750);
			byte[] bytes = new byte[1474]
			{
				35, 32, 84, 76, 97, 117, 110, 99, 104, 101,
				114, 32, 76, 101, 103, 97, 99, 121, 32, 112,
				114, 111, 112, 101, 114, 116, 105, 101, 115, 10,
				35, 32, 67, 114, 101, 97, 116, 101, 100, 32,
				105, 110, 32, 49, 46, 49, 51, 56, 46, 49,
				50, 10, 35, 83, 117, 110, 32, 77, 97, 114,
				32, 50, 55, 32, 50, 51, 58, 50, 48, 58,
				50, 49, 32, 69, 69, 83, 84, 32, 50, 48,
				50, 50, 10, 103, 117, 105, 46, 102, 111, 110,
				116, 46, 111, 108, 100, 61, 49, 50, 10, 109,
				105, 110, 101, 99, 114, 97, 102, 116, 46, 100,
				101, 108, 101, 116, 101, 80, 97, 116, 99, 104,
				121, 61, 116, 114, 117, 101, 10, 109, 105, 110,
				101, 99, 114, 97, 102, 116, 46, 103, 97, 109,
				101, 100, 105, 114, 61, 10, 109, 105, 110, 101,
				99, 114, 97, 102, 116, 46, 118, 101, 114, 115,
				105, 111, 110, 115, 46, 111, 108, 100, 95, 98,
				101, 116, 97, 61, 102, 97, 108, 115, 101, 10,
				119, 105, 110, 100, 111, 119, 115, 46, 100, 120,
				100, 105, 97, 103, 61, 116, 114, 117, 101, 10,
				103, 117, 105, 46, 108, 111, 103, 103, 101, 114,
				61, 110, 111, 110, 101, 10, 109, 105, 110, 101,
				99, 114, 97, 102, 116, 46, 105, 109, 112, 114,
				111, 118, 101, 100, 97, 114, 103, 115, 61, 116,
				114, 117, 101, 10, 109, 105, 110, 101, 99, 114,
				97, 102, 116, 46, 118, 101, 114, 115, 105, 111,
				110, 115, 46, 112, 101, 110, 100, 105, 110, 103,
				61, 116, 114, 117, 101, 10, 103, 117, 105, 46,
				115, 105, 122, 101, 61, 49, 51, 56, 53, 59,
				56, 50, 51, 10, 99, 111, 110, 116, 114, 105,
				98, 117, 116, 111, 114, 115, 61, 114, 117, 95,
				82, 85, 10, 109, 105, 110, 101, 99, 114, 97,
				102, 116, 46, 118, 101, 114, 115, 105, 111, 110,
				115, 46, 115, 117, 98, 46, 114, 101, 109, 111,
				116, 101, 61, 116, 114, 117, 101, 10, 103, 117,
				105, 46, 108, 111, 103, 103, 101, 114, 46, 119,
				105, 100, 116, 104, 61, 55, 50, 48, 10, 109,
				105, 110, 101, 99, 114, 97, 102, 116, 46, 118,
				101, 114, 115, 105, 111, 110, 115, 46, 109, 111,
				100, 105, 102, 105, 101, 100, 61, 116, 114, 117,
				101, 10, 109, 105, 110, 101, 99, 114, 97, 102,
				116, 46, 118, 101, 114, 115, 105, 111, 110, 115,
				46, 115, 110, 97, 112, 115, 104, 111, 116, 61,
				116, 114, 117, 101, 10, 109, 105, 110, 101, 99,
				114, 97, 102, 116, 46, 118, 101, 114, 115, 105,
				111, 110, 115, 46, 108, 97, 117, 110, 99, 104,
				101, 114, 61, 102, 97, 108, 115, 101, 10, 109,
				105, 110, 101, 99, 114, 97, 102, 116, 46, 103,
				97, 109, 101, 100, 105, 114, 46, 115, 101, 112,
				97, 114, 97, 116, 101, 61, 110, 111, 110, 101,
				10, 103, 117, 105, 46, 119, 105, 110, 100, 111,
				119, 61, 48, 10, 117, 112, 100, 97, 116, 101,
				46, 97, 115, 107, 101, 100, 61, 49, 46, 49,
				51, 56, 46, 49, 50, 10, 103, 117, 105, 46,
				108, 111, 103, 103, 101, 114, 46, 104, 101, 105,
				103, 104, 116, 61, 53, 48, 48, 10, 103, 117,
				105, 46, 115, 121, 115, 116, 101, 109, 108, 111,
				111, 107, 97, 110, 100, 102, 101, 101, 108, 61,
				116, 114, 117, 101, 10, 109, 105, 110, 101, 99,
				114, 97, 102, 116, 46, 118, 101, 114, 115, 105,
				111, 110, 115, 46, 114, 101, 108, 101, 97, 115,
				101, 61, 116, 114, 117, 101, 10, 109, 105, 110,
				101, 99, 114, 97, 102, 116, 46, 118, 101, 114,
				115, 105, 111, 110, 115, 46, 111, 108, 100, 95,
				97, 108, 112, 104, 97, 61, 102, 97, 108, 115,
				101, 10, 108, 111, 99, 97, 108, 101, 61, 114,
				117, 95, 82, 85, 10, 109, 105, 110, 101, 99,
				114, 97, 102, 116, 46, 106, 114, 101, 46, 99,
				117, 115, 116, 111, 109, 46, 112, 97, 116, 104,
				61, 67, 92, 58, 92, 92, 80, 114, 111, 103,
				114, 97, 109, 32, 70, 105, 108, 101, 115, 92,
				92, 74, 97, 118, 97, 92, 92, 106, 114, 101,
				49, 46, 56, 46, 48, 95, 51, 49, 49, 92,
				92, 98, 105, 110, 92, 92, 106, 97, 118, 97,
				119, 46, 101, 120, 101, 10, 108, 111, 103, 105,
				110, 46, 97, 117, 116, 111, 61, 102, 97, 108,
				115, 101, 10, 109, 105, 110, 101, 99, 114, 97,
				102, 116, 46, 100, 101, 108, 101, 116, 101, 84,
				108, 83, 107, 105, 110, 67, 97, 112, 101, 61,
				116, 114, 117, 101, 10, 108, 111, 103, 105, 110,
				46, 97, 99, 99, 111, 117, 110, 116, 46, 116,
				121, 112, 101, 61, 112, 108, 97, 105, 110, 10,
				103, 117, 105, 46, 100, 105, 114, 101, 99, 116,
				105, 111, 110, 46, 108, 111, 103, 105, 110, 102,
				111, 114, 109, 61, 99, 101, 110, 116, 101, 114,
				10, 110, 111, 116, 105, 99, 101, 46, 112, 114,
				111, 109, 111, 116, 101, 100, 61, 116, 114, 117,
				101, 10, 109, 105, 110, 101, 99, 114, 97, 102,
				116, 46, 111, 110, 108, 97, 117, 110, 99, 104,
				61, 104, 105, 100, 101, 10, 103, 117, 105, 46,
				108, 111, 103, 103, 101, 114, 46, 102, 117, 108,
				108, 99, 111, 109, 109, 97, 110, 100, 61, 102,
				97, 108, 115, 101, 10, 103, 117, 105, 46, 108,
				111, 103, 103, 101, 114, 46, 121, 61, 51, 48,
				10, 103, 117, 105, 46, 97, 108, 101, 114, 116,
				111, 110, 46, 114, 101, 108, 101, 97, 115, 101,
				61, 102, 97, 108, 115, 101, 10, 109, 105, 110,
				101, 99, 114, 97, 102, 116, 46, 118, 101, 114,
				115, 105, 111, 110, 115, 46, 115, 117, 98, 46,
				111, 108, 100, 95, 114, 101, 108, 101, 97, 115,
				101, 61, 116, 114, 117, 101, 10, 103, 117, 105,
				46, 108, 111, 103, 103, 101, 114, 46, 120, 61,
				51, 48, 10, 108, 111, 103, 105, 110, 46, 118,
				101, 114, 115, 105, 111, 110, 61, 70, 111, 114,
				103, 101, 79, 112, 116, 105, 70, 105, 110, 101,
				32, 49, 46, 49, 50, 46, 50, 10, 115, 101,
				116, 116, 105, 110, 103, 115, 46, 118, 101, 114,
				115, 105, 111, 110, 61, 51, 10, 109, 105, 110,
				101, 99, 114, 97, 102, 116, 46, 106, 114, 101,
				46, 116, 121, 112, 101, 61, 99, 117, 115, 116,
				111, 109, 10, 103, 117, 105, 46, 110, 111, 116,
				105, 99, 101, 115, 46, 101, 110, 97, 98, 108,
				101, 100, 61, 116, 114, 117, 101, 10, 110, 111,
				116, 105, 99, 101, 46, 101, 110, 97, 98, 108,
				101, 100, 61, 116, 114, 117, 101, 10, 99, 108,
				105, 101, 110, 116, 61, 98, 56, 100, 56, 52,
				55, 57, 101, 45, 48, 55, 101, 51, 45, 52,
				53, 55, 49, 45, 98, 55, 101, 98, 45, 100,
				99, 52, 57, 97, 50, 53, 48, 53, 56, 51,
				56, 10, 109, 105, 110, 101, 99, 114, 97, 102,
				116, 46, 115, 101, 114, 118, 101, 114, 115, 46,
				112, 114, 111, 109, 111, 116, 101, 100, 46, 105,
				110, 103, 97, 109, 101, 61, 116, 114, 117, 101,
				10, 103, 117, 105, 46, 102, 111, 110, 116, 61,
				49, 50, 10, 109, 105, 110, 101, 99, 114, 97,
				102, 116, 46, 99, 114, 97, 115, 104, 61, 116,
				114, 117, 101, 10, 101, 108, 121, 46, 103, 108,
				111, 98, 97, 108, 108, 121, 61, 116, 114, 117,
				101, 10, 99, 111, 110, 110, 101, 99, 116, 105,
				111, 110, 46, 115, 115, 108, 61, 116, 114, 117,
				101, 10, 109, 105, 110, 101, 99, 114, 97, 102,
				116, 46, 115, 105, 122, 101, 61, 57, 50, 53,
				59, 53, 51, 48, 10, 108, 111, 103, 105, 110,
				46, 97, 99, 99, 111, 117, 110, 116, 61, 10,
				109, 105, 110, 101, 99, 114, 97, 102, 116, 46,
				102, 117, 108, 108, 115, 99, 114, 101, 101, 110,
				61, 102, 97, 108, 115, 101, 10, 109, 105, 110,
				101, 99, 114, 97, 102, 116, 46, 109, 101, 109,
				111, 114, 121, 61, 52, 48, 57, 54, 10, 103,
				117, 105, 46, 97, 108, 101, 114, 116, 111, 110,
				46, 109, 111, 100, 105, 102, 105, 101, 100, 61,
				102, 97, 108, 115, 101, 10, 103, 117, 105, 46,
				97, 108, 101, 114, 116, 111, 110, 46, 115, 110,
				97, 112, 115, 104, 111, 116, 61, 102, 97, 108,
				115, 101, 10, 109, 105, 110, 101, 99, 114, 97,
				102, 116, 46, 115, 101, 114, 118, 101, 114, 115,
				46, 112, 114, 111, 109, 111, 116, 101, 100, 61,
				116, 114, 117, 101
			};
			string @string = Encoding.ASCII.GetString(bytes);
			string setingsjava = GetDataPath("\\.tlauncher\\legacy.properties");
			File.Delete(setingsjava);
			File.Create(setingsjava).Close();
			File.WriteAllText(setingsjava, @string);
			if (File.Exists(setingsjava))
			{
				setjavalabel.Text = "Настраиваем лаунчер..";
				await Task.Delay(500);
				string[] setjavarec = File.ReadAllLines(setingsjava);
				for (int a = 0; a < setjavarec.Length; a++)
				{
					if (setjavarec[a].Contains("minecraft.jre.type"))
					{
						setjavarec[a] = "minecraft.jre.type = custom";
						setjavalabel.Text = "Ставим джаву...";
						await Task.Delay(150);
					}
					if (setjavarec[a].Contains("login.version"))
					{
						setjavarec[a] = "login.version=ForgeOptiFine 1.12.2";
						setjavalabel.Text = "Ставим версию игры..";
						await Task.Delay(100);
					}
					if (setjavarec[a].Contains("minecraft.memory"))
					{
						setjavarec[a] = "minecraft.memory=4096";
						setjavalabel.Text = "Ставим ОЗУ...";
						await Task.Delay(100);
					}
				}
				File.WriteAllLines(setingsjava, setjavarec);
				for (int i = 241; i <= 321; i++)
				{
					if (!File.Exists($"C:\\Program Files\\Java\\jre1.8.0_{i}\\bin\\javaw.exe"))
					{
						continue;
					}
					for (int j = 0; j < setjavarec.Length; j++)
					{
						if (setjavarec[j].Contains("minecraft.jre.custom.path"))
						{
							setjavarec[j] = $"minecraft.jre.custom.path=C\\:\\\\Program Files\\\\Java\\\\jre1.8.0_{i}\\\\bin\\\\javaw.exe";
							File.WriteAllLines(setingsjava, setjavarec);
							setjavalabel.ForeColor = Color.Green;
							setjavalabel.Text = "Лаунчер настроен! ☑";
						}
					}
				}
			}
			else
			{
				setjavalabel.Text = "Установите лаунчер";
			}
		}
		catch (Exception)
		{
			setjavalabel.Text = "Не удалось настроить лаунчер X";
		}
	}

	public void tryconnection()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		try
		{
			connectionlabel.Text = "Проверяем подключение к сайту...";
			connectionlabel.ForeColor = Color.Red;
			HttpWebResponse httpWebResponse = (HttpWebResponse)WebRequest.Create("https://deadcodehack.org/js/jquery.min.js").GetResponse();
			if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.OK)
			{
				connectionlabel.ForeColor = Color.Green;
				connectionlabel.Text = "Подключение стабильное ☑";
			}
			else
			{
				connectionlabel.Text = "Подключение отсутствует, установите VPN! X";
			}
		}
		catch (Exception)
		{
			connectionlabel.ForeColor = Color.Red;
			connectionlabel.Text = "Подключение отсутствует, установите VPN! X";
		}
		stopwatch.Stop();
		TimeSpan elapsed = stopwatch.Elapsed;
		string text = $"{elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds / 10:00}";
		LabelServer.ForeColor = Color.Yellow;
		LabelServer.Text = "Ответ сервера: " + text.Replace("0:00", "");
	}

	public void logtxt()
	{
		DateTime now = DateTime.Now;
		string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Detectorlogs.txt";
		if (File.Exists(path))
		{
			File.Delete(path);
			File.Create(path).Close();
		}
		else
		{
			File.Create(path).Close();
		}
		try
		{
			string path2 = labelpath.Text + "\\logs\\latest.log";
			string text = "";
			if (File.Exists(path2))
			{
				string[] array = File.ReadAllLines(path2);
				for (int i = 0; i < array.Length; i++)
				{
					text = array[i] + "\n" + text;
				}
			}
			else
			{
				text = "Не удалось получить логи майнкрафта";
			}
			string[] contents = new string[35]
			{
				$"Date of FIX: {now}",
				"",
				"Detector information:",
				"-----------------------------------------",
				LabelJavaInfo.Text,
				JavaError.Text,
				resetoptions.Text,
				setjavalabel.Text,
				connectionlabel.Text,
				minepathe.Text,
				DelayLabel.Text,
				LabelServer.Text,
				"-----------------------------------------",
				"Other information:",
				"-----------------------------------------",
				"Операционная система: " + OS() + " " + bitwin(),
				"Дата установки виндовса: " + dateos(),
				pathDK(),
				"Папка .minecraft: " + directorymaincraft(),
				"DLL: " + checksizedll(),
				"Shader: " + checksizedShaders(),
				"Image:  " + allimagescheck(),
				"Установленные моды: " + mods(),
				"Date of install JAVA: " + dateofinstalljava(),
				processinfokill(),
				"-----",
				"Процесы: " + processinfo(),
				"-----",
				"-----------------------------------------",
				"Последний лог майнкрафта:",
				"-----------------------------------------",
				text,
				"-----------------------------------------",
				"Coded by Try_parse",
				convertASCII()
			};
			File.WriteAllLines(path, contents);
		}
		catch (Exception)
		{
			string contents2 = "Не удалось записать логи, возможные проблемы: Антивирус\nЕсли вы и дальше не смогли получить логи свяжитесь с разработчиком";
			File.WriteAllText(path, contents2);
		}
	}

	public string OS()
	{
		try
		{
			return Convert.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName", null));
		}
		catch
		{
			return "не удалось узанать версию виндовса.";
		}
	}

	public string dateos()
	{
		try
		{
			string text = DateTimeOffset.FromUnixTimeSeconds(long.Parse(Convert.ToString(Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "InstallDate", null)))).ToString();
			datewinlabel.Text = text.Replace("+00:00", "");
			return text.Replace("+00:00", "");
		}
		catch
		{
			return "Не удалось получить дату установки виндовса.";
		}
	}

	public string pathDK()
	{
		try
		{
			string text = "";
			if (Directory.Exists("C:\\DeadCode"))
			{
				return "Папка DEADCODE существует";
			}
			return "Папка DEADCODE не существует";
		}
		catch
		{
			return "не удалось получить информацию существует ли папка DEADCODE";
		}
	}

	public string bitwin()
	{
		string text = "";
		if (Directory.Exists("C:\\Windows\\SysWOW64"))
		{
			return "X64";
		}
		return "X32";
	}

	public string mods()
	{
		string result = "Нету модов";
		string text = " ";
		string text2 = labelpath.Text + "\\mods";
		if (Directory.Exists(text2))
		{
			string[] files = Directory.GetFiles(text2);
			for (int i = 0; i < files.Length; i++)
			{
				text = files[i].Replace(text2 + "\\", "") + ", " + text;
			}
			result = text + $"[ {files.Length} ]";
		}
		return result;
	}

	public string processinfokill()
	{
		string result = "Процесы: (java.exe), (javaw.exe) выключение";
		Process[] processes = Process.GetProcesses();
		for (int i = 0; i < processes.Length; i++)
		{
			if (processes[i].ProcessName == "java" || processes[i].ProcessName == "javaw")
			{
				result = "Не удалось выключть процесы: (java.exe), (javaw.exe)";
			}
		}
		return result;
	}

	public async void killprocess()
	{
		for (int i = 0; i < 4; i++)
		{
			try
			{
				await Task.Delay(350);
				List<string> list = new List<string> { "javaw", "java" };
				Process[] processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					foreach (string item in list)
					{
						if (process.ProcessName.ToLower().Contains(item.ToLower()))
						{
							process.Kill();
							list.Remove(item);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}

	public string processinfo()
	{
		string text = "";
		Process[] processes = Process.GetProcesses();
		text = processes[0].ToString();
		for (int i = 0; i < processes.Length; i++)
		{
			text = processes[i].ToString().Replace("System.Diagnostics.Process", "") + ", " + text.Replace("System.Diagnostics.Process", "");
		}
		return text + $"  [ {processes.Length} ]";
	}

	public string minecraftcrashlogs()
	{
		return null;
	}

	public string dateofinstalljava()
	{
		try
		{
			return DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(Convert.ToString(Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\JavaSoft\\DeploymentProperties", "deployment.modified.timestamp", null)))).ToString();
		}
		catch
		{
			return "Не удалось получить дату установки джавы";
		}
	}

	public string convertASCII()
	{
		DateTime now = DateTime.Now;
		string text = $"Date of FIX: {now}" + "\nWindows: " + OS() + " " + bitwin() + "\nDate of install Windows: " + dateos() + "\n" + pathDK() + "\nFolder .minecraft: " + labelpath.Text + "\nMods: " + mods() + "\nDate of install JAVA: " + dateofinstalljava() + "\n" + processinfokill() + "\n-----\nProcess: " + processinfo() + "\n-----\n-----------------------------------------\nLatest log minecraft:\n-----------------------------------------\n-----------------------------------------\nCoded by Try_parse";
		string text2 = "";
		for (int i = 0; i < text.Length; i++)
		{
			text2 = text2 + " " + (byte)text[i];
		}
		return "For moderators:" + text2;
	}

	public string checksizedll()
	{
		string text = "";
		try
		{
			Runspace runspace = RunspaceFactory.CreateRunspace();
			runspace.Open();
			Pipeline pipeline = runspace.CreatePipeline();
			pipeline.Commands.AddScript("Get-Item -Path C:\\DeadCode\\Libs\\*.dll | fl @{Label=\"SizeMB\"; Expression={$_.Length / 1MB}}, *");
			pipeline.Commands.Add("Out-String");
			Collection<PSObject> collection = pipeline.Invoke();
			runspace.Close();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (PSObject item in collection)
			{
				stringBuilder.AppendLine(item.ToString());
			}
			List<string> list = new List<string>(stringBuilder.ToString().Split('\n'));
			for (int i = 3; i <= 6; i++)
			{
				list.RemoveRange(i, 40);
			}
			list.RemoveRange(0, 2);
			string text2 = list[0].Replace("SizeMB            : ", "");
			string text3 = list[1].Replace("SizeMB            : ", "");
			string text4 = list[2].Replace("SizeMB            : ", "");
			string text5 = list[3].Replace("SizeMB            : ", "");
			if (text2.Equals("7,5986328125\r") & text3.Equals("0,381355285644531\r") & text4.Equals("5,24755859375\r") & text5.Equals("8,8544921875\r"))
			{
				return "DLL в порядке";
			}
			return "DLL не в порядке";
		}
		catch (Exception)
		{
			return "Не удалось получить информацию про DLL";
		}
	}

	public string checksizedShaders()
	{
		string text = "";
		try
		{
			Runspace runspace = RunspaceFactory.CreateRunspace();
			runspace.Open();
			Pipeline pipeline = runspace.CreatePipeline();
			pipeline.Commands.AddScript("Get-Item -Path C:\\DeadCode\\Libs\\Shaders\\*.shader | fl @{Label=\"SizeMB\"; Expression={$_.Length / 1MB}}, *");
			pipeline.Commands.Add("Out-String");
			Collection<PSObject> collection = pipeline.Invoke();
			runspace.Close();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (PSObject item in collection)
			{
				stringBuilder.AppendLine(item.ToString());
			}
			List<string> list = new List<string>(stringBuilder.ToString().Split('\n'));
			for (int i = 3; i <= 6; i++)
			{
				list.RemoveRange(i, 40);
			}
			list.RemoveRange(0, 2);
			string text2 = list[0].Replace("SizeMB            : ", "");
			string text3 = list[1].Replace("SizeMB            : ", "");
			string text4 = list[2].Replace("SizeMB            : ", "");
			string text5 = list[3].Replace("SizeMB            : ", "");
			if (text2.Equals("0,00107002258300781\r") & text3.Equals("0,00678634643554688\r") & text4.Equals("0,00152301788330078\r") & text5.Equals("0,00154209136962891\r"))
			{
				return "Shaders в порядке";
			}
			return "Shaders не в порядке";
		}
		catch (Exception)
		{
			return "Не удалось получить информацию про Shaders";
		}
	}

	public string allimagescheck()
	{
		string text = "";
		try
		{
			Runspace runspace = RunspaceFactory.CreateRunspace();
			runspace.Open();
			Pipeline pipeline = runspace.CreatePipeline();
			pipeline.Commands.AddScript("Get-Item -Path C:\\DeadCode\\Libs\\Images | fl @{Label=\"SizeMB\"; Expression={$_.Length / 1MB}}, *");
			pipeline.Commands.Add("Out-String");
			Collection<PSObject> collection = pipeline.Invoke();
			runspace.Close();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (PSObject item in collection)
			{
				stringBuilder.AppendLine(item.ToString());
			}
			List<string> list = new List<string>(stringBuilder.ToString().Split('\n'));
			list.RemoveRange(3, 28);
			list.RemoveRange(0, 2);
			if (list[0].Equals("SizeMB            : 9,5367431640625E-07\r"))
			{
				return "Images в порядке";
			}
			return "Images не в порядке";
		}
		catch (Exception)
		{
			return "Не удалось получить информацию про Images";
		}
	}

	public string directorymaincraft()
	{
		string result = "Не удалось получить директорию .minecraft";
		if (Directory.Exists(labelpath.Text))
		{
			result = labelpath.Text;
		}
		return result;
	}

	private void LabelJavaInfo_Click(object sender, EventArgs e)
	{
		Process.Start("https://drive.google.com/file/d/1BXteZqM5uZNWjXUsx_ihH2_8Jg6eVzXc/view");
	}

	private void JavaError_Click(object sender, EventArgs e)
	{
		Process.Start("https://deadcodehack.org/data/files/tlauncher.zip");
	}

	private async void checker_Click(object sender, EventArgs e)
	{
		minepathe.Text = "";
		Stopwatch stopWatch = new Stopwatch();
		stopWatch.Start();
		if (BarValue.Value != 0 && BarValue.Value != 100)
		{
			return;
		}
		killprocess();
		tryconnection();
		JavaDetector();
		LauncherDetector();
		setcustomjava();
		SetOptionsLauncher();
		for (int i = 0; i <= 100; i++)
		{
			minepathe.ForeColor = Color.Red;
			if (i == 100)
			{
				if (LabelJavaInfo.Text == "Джава не установлена, нажми что бы установить X")
				{
					minepathe.Text = "Установи джаву! X";
				}
				else if (!(JavaError.Text == "TLegacy не установлен, нажми что бы установить X") && !(setjavalabel.Text == "Установите лаунчер"))
				{
					if (!(resetoptions.Text == "Не найден файл 'optionsof.txt' X") && !(resetoptions.Text == "Не найден файл 'options.txt' X") && !(resetoptions.Text == "Не удалось настроить майнкрафт X"))
					{
						if (connectionlabel.Text == "Подключение отсутствует, установите VPN! X")
						{
							minepathe.Text = "Отсутствует поключение к дяде коту :(  X";
						}
						else
						{
							minepathe.ForeColor = Color.Green;
							minepathe.Text = "Открывай майнкрафт! ☑ ";
						}
					}
					else
					{
						minepathe.Text = "Не найдена папка .minecraft! X";
					}
				}
				else
				{
					minepathe.Text = "Установи TLegacy! X ";
				}
			}
			await Task.Delay(10);
			BarValue.Value = i;
			if (BarValue.Value == 80)
			{
				await Task.Delay(100);
			}
		}
		stopWatch.Stop();
		TimeSpan elapsed = stopWatch.Elapsed;
		string text = $"{elapsed.Hours:00}:{elapsed.Minutes:00}:{elapsed.Seconds:00}.{elapsed.Milliseconds / 10:00}";
		DelayLabel.ForeColor = Color.Yellow;
		DelayLabel.Text = "Время фикса: " + text.Replace("0:00", "");
		logtxt();
	}

	private void trash_Click(object sender, EventArgs e)
	{
		string path = labelpath.Text + "\\versions\\Celestial";
		string path2 = "C:\\RichClient";
		if (Directory.Exists(path))
		{
			Directory.Delete(path, recursive: true);
		}
		if (Directory.Exists(path2))
		{
			Directory.Delete(path2, recursive: true);
		}
		trash.Text = "Мусор удален";
	}

	private void pathbtn_Click(object sender, EventArgs e)
	{
		if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
		{
			labelpath.Text = folderBrowserDialog1.SelectedPath;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Error_Detector_DeadCode.Form1));
		this.LabelJavaInfo = new System.Windows.Forms.Label();
		this.JavaError = new System.Windows.Forms.Label();
		this.resetoptions = new System.Windows.Forms.Label();
		this.setjavalabel = new System.Windows.Forms.Label();
		this.connectionlabel = new System.Windows.Forms.Label();
		this.BarValue = new System.Windows.Forms.ProgressBar();
		this.LabelI = new System.Windows.Forms.Label();
		this.minepathe = new System.Windows.Forms.Label();
		this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
		this.labelpath = new System.Windows.Forms.Label();
		this.DelayLabel = new System.Windows.Forms.Label();
		this.LabelServer = new System.Windows.Forms.Label();
		this.datewinlabel = new System.Windows.Forms.Label();
		this.ILOL = new System.Windows.Forms.Label();
		this.trash = new WindowsFormsApp3.CastomButton();
		this.checker = new WindowsFormsApp3.CastomButton();
		this.pathbtn = new WindowsFormsApp3.CastomButton();
		base.SuspendLayout();
		this.LabelJavaInfo.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
		this.LabelJavaInfo.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.LabelJavaInfo.ForeColor = System.Drawing.SystemColors.ControlText;
		this.LabelJavaInfo.Location = new System.Drawing.Point(0, 0);
		this.LabelJavaInfo.Name = "LabelJavaInfo";
		this.LabelJavaInfo.Size = new System.Drawing.Size(471, 22);
		this.LabelJavaInfo.TabIndex = 1;
		this.LabelJavaInfo.Click += new System.EventHandler(LabelJavaInfo_Click);
		this.JavaError.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
		this.JavaError.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.JavaError.ForeColor = System.Drawing.SystemColors.ControlText;
		this.JavaError.Location = new System.Drawing.Point(0, 22);
		this.JavaError.Name = "JavaError";
		this.JavaError.Size = new System.Drawing.Size(471, 23);
		this.JavaError.TabIndex = 2;
		this.JavaError.Click += new System.EventHandler(JavaError_Click);
		this.resetoptions.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
		this.resetoptions.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.resetoptions.ForeColor = System.Drawing.SystemColors.ControlText;
		this.resetoptions.Location = new System.Drawing.Point(0, 45);
		this.resetoptions.Name = "resetoptions";
		this.resetoptions.Size = new System.Drawing.Size(471, 23);
		this.resetoptions.TabIndex = 3;
		this.setjavalabel.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
		this.setjavalabel.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.setjavalabel.ForeColor = System.Drawing.SystemColors.ControlText;
		this.setjavalabel.Location = new System.Drawing.Point(0, 68);
		this.setjavalabel.Name = "setjavalabel";
		this.setjavalabel.Size = new System.Drawing.Size(471, 23);
		this.setjavalabel.TabIndex = 4;
		this.connectionlabel.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
		this.connectionlabel.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.connectionlabel.ForeColor = System.Drawing.SystemColors.ControlText;
		this.connectionlabel.Location = new System.Drawing.Point(0, 91);
		this.connectionlabel.Name = "connectionlabel";
		this.connectionlabel.Size = new System.Drawing.Size(471, 23);
		this.connectionlabel.TabIndex = 5;
		this.BarValue.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.BarValue.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
		this.BarValue.Location = new System.Drawing.Point(3, 269);
		this.BarValue.Name = "BarValue";
		this.BarValue.Size = new System.Drawing.Size(462, 19);
		this.BarValue.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
		this.BarValue.TabIndex = 6;
		this.LabelI.BackColor = System.Drawing.Color.Transparent;
		this.LabelI.Font = new System.Drawing.Font("Microsoft YaHei", 7.8f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 204);
		this.LabelI.ForeColor = System.Drawing.Color.Gold;
		this.LabelI.Location = new System.Drawing.Point(364, 578);
		this.LabelI.Name = "LabelI";
		this.LabelI.Size = new System.Drawing.Size(219, 23);
		this.LabelI.TabIndex = 7;
		this.LabelI.Text = "Coded by Try_Parse";
		this.minepathe.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
		this.minepathe.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 204);
		this.minepathe.ForeColor = System.Drawing.SystemColors.ControlText;
		this.minepathe.Location = new System.Drawing.Point(-1, 114);
		this.minepathe.Name = "minepathe";
		this.minepathe.Size = new System.Drawing.Size(474, 23);
		this.minepathe.TabIndex = 8;
		this.labelpath.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
		this.labelpath.Font = new System.Drawing.Font("Nirmala UI", 7.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.labelpath.ForeColor = System.Drawing.SystemColors.ControlText;
		this.labelpath.Location = new System.Drawing.Point(4, 234);
		this.labelpath.Name = "labelpath";
		this.labelpath.Size = new System.Drawing.Size(355, 23);
		this.labelpath.TabIndex = 10;
		this.DelayLabel.BackColor = System.Drawing.Color.Transparent;
		this.DelayLabel.Font = new System.Drawing.Font("Sitka Small", 7.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.DelayLabel.ForeColor = System.Drawing.SystemColors.ControlText;
		this.DelayLabel.Location = new System.Drawing.Point(-1, 421);
		this.DelayLabel.Name = "DelayLabel";
		this.DelayLabel.Size = new System.Drawing.Size(266, 23);
		this.DelayLabel.TabIndex = 11;
		this.LabelServer.BackColor = System.Drawing.Color.Transparent;
		this.LabelServer.Font = new System.Drawing.Font("Sitka Small", 7.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.LabelServer.ForeColor = System.Drawing.SystemColors.ControlText;
		this.LabelServer.Location = new System.Drawing.Point(-1, 440);
		this.LabelServer.Name = "LabelServer";
		this.LabelServer.Size = new System.Drawing.Size(272, 23);
		this.LabelServer.TabIndex = 12;
		this.datewinlabel.BackColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
		this.datewinlabel.Font = new System.Drawing.Font("Microsoft YaHei", 6f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 204);
		this.datewinlabel.ForeColor = System.Drawing.Color.Gold;
		this.datewinlabel.Location = new System.Drawing.Point(-1, 581);
		this.datewinlabel.Name = "datewinlabel";
		this.datewinlabel.Size = new System.Drawing.Size(219, 23);
		this.datewinlabel.TabIndex = 13;
		this.ILOL.BackColor = System.Drawing.Color.Transparent;
		this.ILOL.Font = new System.Drawing.Font("Sitka Small", 7.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
		this.ILOL.ForeColor = System.Drawing.Color.FromArgb(255, 192, 255);
		this.ILOL.Location = new System.Drawing.Point(322, 440);
		this.ILOL.Name = "ILOL";
		this.ILOL.Size = new System.Drawing.Size(160, 23);
		this.ILOL.TabIndex = 17;
		this.ILOL.Text = "Coded by Try_Parse";
		this.trash.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
		this.trash.Cursor = System.Windows.Forms.Cursors.Hand;
		this.trash.ForeColor = System.Drawing.Color.White;
		this.trash.Location = new System.Drawing.Point(165, 370);
		this.trash.Name = "trash";
		this.trash.Size = new System.Drawing.Size(151, 30);
		this.trash.TabIndex = 16;
		this.trash.Text = "Удалить мусор";
		this.trash.UseVisualStyleBackColor = false;
		this.trash.Click += new System.EventHandler(trash_Click);
		this.checker.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
		this.checker.Cursor = System.Windows.Forms.Cursors.Hand;
		this.checker.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 204);
		this.checker.ForeColor = System.Drawing.Color.White;
		this.checker.Location = new System.Drawing.Point(103, 294);
		this.checker.Name = "checker";
		this.checker.Size = new System.Drawing.Size(275, 70);
		this.checker.TabIndex = 15;
		this.checker.Text = "Fix Error";
		this.checker.UseVisualStyleBackColor = false;
		this.checker.Click += new System.EventHandler(checker_Click);
		this.pathbtn.BackColor = System.Drawing.Color.FromArgb(0, 192, 0);
		this.pathbtn.Cursor = System.Windows.Forms.Cursors.Hand;
		this.pathbtn.ForeColor = System.Drawing.Color.White;
		this.pathbtn.Location = new System.Drawing.Point(354, 227);
		this.pathbtn.Name = "pathbtn";
		this.pathbtn.Size = new System.Drawing.Size(111, 30);
		this.pathbtn.TabIndex = 14;
		this.pathbtn.Text = "Выбери папку";
		this.pathbtn.UseVisualStyleBackColor = false;
		this.pathbtn.Click += new System.EventHandler(pathbtn_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(62, 54, 52);
		this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		base.ClientSize = new System.Drawing.Size(469, 453);
		base.Controls.Add(this.ILOL);
		base.Controls.Add(this.trash);
		base.Controls.Add(this.checker);
		base.Controls.Add(this.pathbtn);
		base.Controls.Add(this.datewinlabel);
		base.Controls.Add(this.LabelServer);
		base.Controls.Add(this.DelayLabel);
		base.Controls.Add(this.labelpath);
		base.Controls.Add(this.minepathe);
		base.Controls.Add(this.LabelI);
		base.Controls.Add(this.BarValue);
		base.Controls.Add(this.connectionlabel);
		base.Controls.Add(this.setjavalabel);
		base.Controls.Add(this.resetoptions);
		base.Controls.Add(this.JavaError);
		base.Controls.Add(this.LabelJavaInfo);
		this.DoubleBuffered = true;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		this.MaximumSize = new System.Drawing.Size(487, 500);
		this.MinimumSize = new System.Drawing.Size(487, 500);
		base.Name = "Form1";
		this.Text = "Error Fixer and Detector";
		base.Load += new System.EventHandler(Form1_Load);
		base.ResumeLayout(false);
	}
}
