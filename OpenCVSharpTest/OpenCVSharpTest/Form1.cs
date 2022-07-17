using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using OpenCvSharp.Extensions;

namespace UmamusumeChoicesChecker
{
    public partial class Form1 : Form
    {
        #region "const"
        //基本フォルダパス
        const string DEFAULT_FOLDER_PATH = @"C:\Users\nekok\Desktop\test";
        //選択肢イメージパス
        const string CHOICES_IMAGE_FOLDER_PATH = "ChoicesImage";
        //キャラ別選択肢イメージパス
        const string CHARACTER_CHOICES_IMAGE_FOLDER_PATH = "Character";
        //カード別選択肢イメージパス
        const string CARD_CHOICES_IMAGE_FOLDER_PATH = "Card";

        //選択肢CSVパス
        const string CHOICES_CSV_FOLDER_PATH = "ChoicesCSV";
        //キャラ別選択肢CSVファイル名
        const string CHARACTER_CHOICES_CSV = "CharacterChoices.csv";
        //カード別選択肢CSVファイル名
        const string CARD_CHOICES_CSV = "CardChoices.csv";
        //テンプレートマッチング対象ファイル名
        const string MATCHING_IMAGE = "MatchingImage.bmp";
        //（テスト用）テンプレートマッチング対象ファイル名
        const string MATCHING_IMAGE_TEST = "MatchingImage_test.bmp";
        #endregion

        #region"モジュール変数"
        //選択肢イメージパス
        String m_ChoicesImagePath = string.Empty;
        //キャラ別選択肢イメージパス
        String m_CharacterChoicesImagePath = string.Empty;
        //カード別選択肢イメージパス
        String m_CardChoicesImagePath = string.Empty;

        //選択肢CSVパス
        String m_ChoicesCSVPath = string.Empty;

        //テンプレートマッチング対象イメージパス
        String m_MatchingImagePath = string.Empty;

        //キャラ別選択肢イメージリスト
        FileInfo[] m_CharacterChoicesImageList = null;
        //カード別選択肢イメージリスト
        FileInfo[] m_CardChoicesImageList = null;

        //キャラ別ステータス情報リスト
        List<string> m_CharacterStatusDataList = new List<string>();
        //カード別ステータス情報リスト
        List<string> m_CardStatusDataList = new List<string>();

        //スレッドタイマー
        System.Threading.Timer m_timer;

        //マッチした画像の番号
        int m_MatchingNo = 0;

        //マッチング対象
        int m_MatTag = 0;

        //現在の選択肢イメージのパス
        String m_NowChoicesImagePath = string.Empty;

        //選択肢が3つある場合のフラグ
        bool m_ThreeChoicesFlg = false;

        //前回のマッチング結果を保持するリスト
        List<String> m_LastResultList = new List<string>();

        //エラーメッセージ
        String m_ErrMsg = String.Empty;
        #endregion

        //マッチング対象
        public enum MatchingTarget
        {
            Character,
            Card,
        }

        public Form1()
        {
            InitializeComponent();

            InitializeControl();
            btnCheckEnd.Enabled = false;

            //選択肢イメージパス
            m_ChoicesImagePath = Path.Combine(DEFAULT_FOLDER_PATH, CHOICES_IMAGE_FOLDER_PATH);
            //キャラ別選択肢イメージパス
            m_CharacterChoicesImagePath = Path.Combine(m_ChoicesImagePath, CHARACTER_CHOICES_IMAGE_FOLDER_PATH);
            //カード別選択肢イメージパス
            m_CardChoicesImagePath = Path.Combine(m_ChoicesImagePath, CARD_CHOICES_IMAGE_FOLDER_PATH);

            //選択肢CSVパス
            m_ChoicesCSVPath = Path.Combine(DEFAULT_FOLDER_PATH, CHOICES_CSV_FOLDER_PATH);

            //テンプレートマッチング対象イメージパス
            m_MatchingImagePath = Path.Combine(DEFAULT_FOLDER_PATH, MATCHING_IMAGE);

            //選択肢イメージを全て取得する
            DirectoryInfo CharacterChoicesImage = new DirectoryInfo(m_CharacterChoicesImagePath);
            DirectoryInfo CardChoicesImage = new DirectoryInfo(m_CardChoicesImagePath);
            m_CharacterChoicesImageList = CharacterChoicesImage.GetFiles("*.png", SearchOption.AllDirectories);
            m_CardChoicesImageList = CardChoicesImage.GetFiles("*.png", SearchOption.AllDirectories);

            //選択肢CSVを全て読み取る
            ReadChoicesCSV(CHARACTER_CHOICES_CSV);
            ReadChoicesCSV(CARD_CHOICES_CSV);
        }

        /// <summary>
        /// 判定開始ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckStartClicked(object sender, EventArgs e)
        {
            //5秒間隔でマッチング処理を開始する
            TimerCallback timerDelegate = new TimerCallback(MatchingProcess);
            m_timer = new System.Threading.Timer(timerDelegate, null, 0, 5000);
            btnCheckStart.Text = "判定中です！";
            btnCheckStart.Enabled = false;
            btnCheckEnd.Enabled = true;
        }

        /// <summary>
        /// 判定終了ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckEndClicked(object sender, EventArgs e)
        {
            m_timer.Dispose();
            m_LastResultList.Clear();
            InitializeControl();
            btnCheckStart.Enabled = true;
            btnCheckEnd.Enabled = false;
            btnCheckStart.Text = "判定開始！";
        }

        /// <summary>
        /// 選択肢CSVを読み取る
        /// </summary>
        /// <param name="CSVName">読み取るCSV名</param>
        private void ReadChoicesCSV(string CSVName)
        {
            StreamReader sr = new StreamReader(Path.Combine(m_ChoicesCSVPath, CSVName));
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    switch (CSVName)
                    {
                        //キャラ別選択肢
                        case CHARACTER_CHOICES_CSV:
                            m_CharacterStatusDataList.Add(line);
                            break;
                        //カード別選択肢
                        case CARD_CHOICES_CSV:
                            m_CardStatusDataList.Add(line);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// マッチング処理
        /// </summary>
        /// <param name="o"></param>
        private void MatchingProcess(object o)
        {
            if (this.InvokeRequired)
            {
                // コントロールを生成したスレッドに処理を委譲する
                this.Invoke((MethodInvoker)delegate () { MatchingProcess(o); });
                return;
            }

            try
            {
                //画面全体のスクリーンショットをキャプチャ
                Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    //画面全体をコピーする
                    g.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), bmp.Size);
                }
                bmp.Save(Path.Combine(m_MatchingImagePath));

                //マッチング結果
                bool matchingResultFlg = false;

                //キャラ別・カード別でテンプレートマッチを行う
                if (TempleteMatch(m_CharacterChoicesImageList))
                {
                    matchingResultFlg = true;
                    m_MatTag = (int)MatchingTarget.Character;
                }
                else if (TempleteMatch(m_CardChoicesImageList))
                {
                    matchingResultFlg = true;
                    m_MatTag = (int)MatchingTarget.Card;
                }

                //前回マッチング結果と同じかどうかのフラグ
                bool sameResultFlg = false;

                if (matchingResultFlg)
                {
                    //マッチした場合

                    //マッチング結果によっては選択肢が3つから2つに減るため、一度画面を初期化
                    InitializeControl();

                    lblStatus1.Visible = true;
                    lblStatus2.Visible = true;
                    lblStatus3.Visible = true;

                    //画面に表示するステータス情報を取得する
                    List<string> dispStatusList = GetDispStatusDataList();

                    //画面に表示する選択肢イメージ（カット済み）を取得する
                    List<Image> dispImageList = CutChoicesImageList();

                    //選択肢1つ目
                    picChoices1.Image = dispImageList[0];
                    lblStatus1.Text = dispStatusList[0];

                    //選択肢2つ目
                    picChoices2.Image = dispImageList[1];
                    lblStatus2.Text = dispStatusList[1];

                    if (m_ThreeChoicesFlg)
                    {
                        //選択肢3つ目がある場合
                        picChoices3.Image = dispImageList[2];
                        lblStatus3.Text = dispStatusList[2];
                    }

                    //前回のマッチング結果と今回のマッチング結果を比較
                    if (m_LastResultList.Count > 0)
                    {
                        foreach (string resultStatus in dispStatusList)
                        {
                            if (m_LastResultList[dispStatusList.IndexOf(resultStatus)] == resultStatus)
                            {
                                //前回のマッチング結果と同じ場合
                                sameResultFlg = true;
                            }
                            else
                            {
                                sameResultFlg = false;
                                break;
                            }
                        }
                    }

                    if (!sameResultFlg)
                    {
                        //前回のマッチング結果と異なる場合、ラベルの色を変更する
                        ChangeChoicesLabelColorTo(Color.Red);
                    }

                    //保持していた前回のマッチング結果をクリアする
                    m_LastResultList.Clear();

                    //今回のマッチング結果を保持する
                    foreach (string resultStatus in dispStatusList)
                    {
                        m_LastResultList.Add(resultStatus);
                    }
                }
                else
                {
                    //マッチしなかった場合
                    //前回結果が残って、文字色が赤のままになってしまう場合があるため、画面を初期化
                    ChangeChoicesLabelColorTo(Color.Black);
                }
            }
            catch (Exception)
            {
                if (m_ErrMsg == String.Empty)
                {
                    m_ErrMsg = "マッチング処理でエラーが発生しました。";
                }
                //メッセージボックスを表示する
                MessageBox.Show(m_ErrMsg,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// テンプレートマッチング
        /// </summary>
        /// <param name="choicesImageList">選択肢イメージリスト</param>
        /// <returns>マッチング結果</returns>
        private bool TempleteMatch(FileInfo[] choicesImageList)
        {
            bool flgMatch = false;

            //1行目はタイトル行のため、1から開始
            m_MatchingNo = 1;

            try
            {
                foreach (FileInfo tempImagePath in choicesImageList)
                {
                    using (Mat mat = new Mat(Path.Combine(m_MatchingImagePath))) //マッチング対象画像
                    using (Mat temp = new Mat(tempImagePath.FullName)) //テンプレート画像
                    using (Mat result = new Mat()) //結果画像
                    {
                        //テンプレートマッチング
                        Cv2.MatchTemplate(mat, temp, result, TemplateMatchModes.CCoeffNormed);

                        //類似度が最大/最小となる画素の位置を調べる
                        OpenCvSharp.Point minloc, maxloc;
                        double minval, maxval;
                        Cv2.MinMaxLoc(result, out minval, out maxval, out minloc, out maxloc);

                        //最大となった類似度のしきい値で判断
                        var threshold = 0.9;
                        if (maxval >= threshold)
                        {
                            //一致していた場合
                            flgMatch = true;
                            m_NowChoicesImagePath = tempImagePath.FullName;
                            break;
                        }
                        else
                        {
                            //次のデータへ
                            m_MatchingNo++;
                        }
                    }
                }
            }
            catch
            {
                m_ErrMsg = "テンプレートマッチングでエラーが発生しました。";
                throw;
            }

            return flgMatch;
        }

        /// <summary>
        /// マッチングした選択肢の画面表示用ステータス情報を取得する
        /// </summary>
        /// <returns>取得したステータス情報</returns>
        private List<string> GetDispStatusDataList()
        {
            List<string> returnList = new List<string>();

            try
            {
                //マッチング対象から対象のステータス情報リストを判定する
                List<String> statusDataList = new List<string>();
                switch (m_MatTag)
                {
                    case (int)MatchingTarget.Character:
                        statusDataList = m_CharacterStatusDataList;
                        break;
                    case (int)MatchingTarget.Card:
                        statusDataList = m_CardStatusDataList;
                        break;
                }

                //対象のステータス情報リストから該当番号のデータを取得する
                string[] itemList = statusDataList[m_MatchingNo].Split(',');

                //@は改行コードに変換して返却リストに追加する
                returnList.Add(itemList[2].Replace("@", "\r\n"));
                returnList.Add(itemList[3].Replace("@", "\r\n"));
                if (itemList[4] != String.Empty)
                {
                    //選択肢3つ目がある場合
                    m_ThreeChoicesFlg = true;
                    returnList.Add(itemList[4].Replace("@", "\r\n"));
                }
                else
                {
                    m_ThreeChoicesFlg = false;
                }
            }
            catch
            {
                m_ErrMsg = "画面表示用ステータス情報取得でエラーが発生しました。";
                throw;
            }

            return returnList;
        }

        /// <summary>
        /// 選択肢イメージのカット（2分割・3分割）
        /// </summary>
        /// <returns>カットした選択肢イメージのリスト</returns>
        private List<Image> CutChoicesImageList()
        {
            List<Image> returnImageList = new List<Image>();

            try
            {
                //縦分割数
                int cutNum;
                if (m_ThreeChoicesFlg)
                {
                    //選択肢3つ目がある場合
                    cutNum = 3;
                }
                else
                {
                    cutNum = 2;
                }

                //カット対象の選択肢イメージ
                Mat inputImage = new Mat(m_NowChoicesImagePath);

                int height = inputImage.Height; //入力画像の縦の長さ
                int width = inputImage.Width; //入力画像の横の長さ

                int remainderHeight = height % cutNum; //縦方向の余り
                int[] heightList = new int[cutNum]; //分割後の画像の縦の長さを入れる配列

                //縦分割数の数だけ分割
                for (int r = 0; r < cutNum; r++)
                {
                    if (remainderHeight > 0)
                    {
                        heightList[r] = height / cutNum + 1; //余りを割り当てる
                        remainderHeight--;
                    }
                    else
                    {
                        heightList[r] = height / cutNum;
                    }
                }

                int y = 0; //分割する画像のy座標

                for (int r = 0; r < cutNum; r++)
                {
                    //分割する画像の(x, y, width, height)をRectに入力
                    Rect imgRect = new Rect(0, y, width, heightList[r]);

                    //分割画像を取得
                    Mat cutImage = inputImage.Clone(imgRect);

                    //画像の出力
                    returnImageList.Add(BitmapConverter.ToBitmap(cutImage));

                    y += heightList[r];
                }
            }
            catch
            {
                m_ErrMsg = "選択肢イメージのカットでエラーが発生しました。";
                throw;
            }

            return returnImageList;
        }

        /// <summary>
        /// コントロールの描画を初期化する
        /// </summary>
        private void InitializeControl()
        {
            ChangeChoicesLabelColorTo(Color.Black);
            picChoices1.Image = null;
            picChoices2.Image = null;
            picChoices3.Image = null;
            lblStatus1.Text = string.Empty;
            lblStatus2.Text = string.Empty;
            lblStatus3.Text = string.Empty;
            lblStatus1.Visible = false;
            lblStatus2.Visible = false;
            lblStatus3.Visible = false;
        }

        /// <summary>
        /// 「選択肢１～３」ラベルの色を変更する
        /// </summary>
        /// <param name="clr">変更したい色</param>
        private void ChangeChoicesLabelColorTo(Color clr)
        {
            lblChoices1.ForeColor = lblChoices2.ForeColor = clr;
            if (m_ThreeChoicesFlg)
            {
                //選択肢3つ目がある場合
                lblChoices3.ForeColor = clr;
            }
        }
    }
}
