using System;
using System.Text;
using Xamarin.Forms;
using System.Diagnostics;
using Multiformats.Hash;
using System.IO;
using Plugin.Media;
using System.Reflection;
using Multiformats.Base;
using System.Threading;
using Multiformats.Hash.Algorithms;
using Ipfs.Api;
using Ipfs;

namespace NethereumWithTraditionalMVVM
{
    public partial class MainPage : ContentPage
    {
        Multihash mh;
        byte[] bytes;

        public MainPage()
        {
            InitializeComponent();
        }

        public string base64StringFromImage = null;

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                string textValue = txtValue.Text;

                //Hash with Mutlihash
                Encoding encoding = Encoding.UTF8;
                bytes = encoding.GetBytes(textValue);

                mh = Multihash.Sum<SHA2_256>(bytes);

                Debug.WriteLine("string bytes after Multihash:" + mh);

                Multibase multibase = Multibase.Base58;
                string checkData = multibase.Encode(mh);

                stringHash.Text = checkData;

                //Hash with IPFS
                CancellationToken token = new CancellationToken(false);

                IpfsClient ipfs = new IpfsClient("http://10.0.3.2:5001");

                IFileSystemNode fileSystemNode = await ipfs.FileSystem.AddTextAsync(textValue, null, token);

                Debug.WriteLine("fileSystemNode Hash:" + fileSystemNode.Id);

                imageHash.Text = fileSystemNode.Id;
            }
            catch (Exception err)
            {
                Debug.WriteLine("Message:" + err.Message);
                Debug.WriteLine("Source:" + err.Source);
                Debug.WriteLine("Stack Trace:" + err.StackTrace);
            }

        }

        public byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        async void pickPhoto(object sender, System.EventArgs e)
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            try
            {
                Stream stream = null;
                var file = await CrossMedia.Current.PickPhotoAsync().ConfigureAwait(true);

                if (file == null)
                    return;

                stream = file.GetStream();
                //  imgIcon.Source = ImageSource.FromStream(() => stream);

                //Hash With Multihash
                Multibase multibase = Multibase.Base58;

                bytes = null;
                mh = null;

                bytes = GetImageStreamAsBytes(stream);

                string hexString = bytes.ToBase64Url();

                if(App.HexString==null)
                {
                    App.HexString = hexString;
                }
                else
                {
                    if(App.HexString==hexString)
                    {
                        Debug.WriteLine("both hex are equal");
                    }
                    else
                    {
                        Debug.WriteLine("Both strings are not equal");
                    }
                }

                Debug.WriteLine(bytes.ToHexString());

                var multihash = Multihash.Sum<SHA2_256>(bytes);

                string checkData = multibase.Encode(multihash);

                stringHash.Text = checkData;

                //Hash with IPFS
                CancellationToken token = new CancellationToken(false);

                IpfsClient ipfs = new IpfsClient("http://10.0.3.2:5001");

                IFileSystemNode fileSystemNode = await ipfs.FileSystem.AddFileAsync(file.Path);

                Debug.WriteLine("fileSystemNode Hash:" + fileSystemNode.Id);

                imageHash.Text = fileSystemNode.Id;

                file.Dispose();

            }
            catch (Exception err)
            {
                Debug.WriteLine("Message:" + err.Message);
                Debug.WriteLine("Source:" + err.Source);
                Debug.WriteLine("Stack Trace:" + err.StackTrace);
            }
        }

        async void localPhoto(object sender, System.EventArgs e)
        {
            //local();

            videoSelection();
        }

        async  void local()
        {
            try
            {
                string imagePath = "NethereumWithTraditionalMVVM.Images.download.jpeg";

                Assembly assembly = typeof(MainPage).GetTypeInfo().Assembly;

                string result;
                using (Stream stream = assembly.GetManifestResourceStream(imagePath))
                {
                    long length = stream.Length;
                    byte[] buffer = new byte[length];
                    stream.Read(buffer, 0, (int)length);

                    bytes = GetImageStreamAsBytes(stream);

                    CancellationToken token = new CancellationToken(false);

                    IpfsClient ipfs = new IpfsClient("http://10.0.3.2:5001");

                    IFileSystemNode fileSystemNode = await ipfs.FileSystem.AddFileAsync(imagePath, null, token);

                    Debug.WriteLine("fileSystemNode Hash:" + fileSystemNode.Id);

                    bytes = null;
                    bytes = GetImageStreamAsBytes(fileSystemNode.DataStream);

                    mh = Multihash.Sum<SHA2_256>(bytes);

                    stringHash.Text = fileSystemNode.Id;

                    Debug.WriteLine("bytes after multihash:" + mh);

                    Multibase multibase = Multibase.Base58;
                    string checkData = multibase.Encode(mh);

                    Debug.WriteLine("Multihash after Base58 Encode:" + checkData);

                    imageHash.Text = checkData;
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine("Message:" + err.Message);
                Debug.WriteLine("Source:" + err.Source);
                Debug.WriteLine("Stack Trace:" + err.StackTrace);
            }
        }

        async void videoSelection()
        {
            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            try
            {
                Stream stream = null;
                var file = await CrossMedia.Current.PickVideoAsync().ConfigureAwait(true);

                if (file == null)
                    return;

                stream = file.GetStream();
                //file.Dispose();
                //  imgIcon.Source = ImageSource.FromStream(() => stream);


                //Hash with Multihash

                Multibase multibase = Multibase.Base58;

                bytes = null;
                mh = null;

                bytes = GetImageStreamAsBytes(stream);

                var multihash = Multihash.Sum<SHA2_256>(bytes);

                string checkData = multibase.Encode(multihash);

                stringHash.Text = checkData;


                //Hash With IPFS

                CancellationToken token = new CancellationToken(false);

                IpfsClient ipfs = new IpfsClient("http://10.0.3.2:5001");

                IFileSystemNode fileSystemNode = await ipfs.FileSystem.AddFileAsync(file.Path, null, token);

                Debug.WriteLine("fileSystemNode Hash:" + fileSystemNode.Id);

                imageHash.Text = fileSystemNode.Id;
            }
            catch (Exception err)
            {
                Debug.WriteLine("Message:" + err.Message);
                Debug.WriteLine("Source:" + err.Source);
                Debug.WriteLine("Stack Trace:" + err.StackTrace);
            }
        }
    }
}
